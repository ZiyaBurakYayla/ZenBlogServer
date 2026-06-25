using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Users.Result;
using ZenBlog.Application.Options;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Persistence.Concrete
{
    public class JwtService(UserManager<AppUser> _userManager, IOptions<JwtTokenOptions> _options) : IJwtService
    {
        private readonly JwtTokenOptions _jwtTokenOptions = _options.Value;
        public async Task<GetLoginQueryResult> GenerateTokenAsync(GetUserQueryResult result)
        {
            var user = await _userManager.FindByNameAsync(result.UserName);
            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_jwtTokenOptions.Key));
            var datetime = DateTime.UtcNow;
            var expiration = datetime.AddMinutes(_jwtTokenOptions.ExpireInMınutes);

            List<Claim> claims = new()
             {
                 new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                 new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                 new Claim(JwtRegisteredClaimNames.Email, user.Email),
                 new Claim("fullName", string.Join("",user.FirstName,user.LastName))
             };

            SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new(
                issuer: _jwtTokenOptions.Issuer,
                audience: _jwtTokenOptions.Audience,
                claims: claims,
                notBefore: datetime,
                expires: expiration,
                signingCredentials: signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return new GetLoginQueryResult
            {
                Token = token,
                ExpirationTime = expiration
            };
        }
    }
}
