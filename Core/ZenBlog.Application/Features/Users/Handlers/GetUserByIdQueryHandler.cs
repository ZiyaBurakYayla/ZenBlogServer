using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Queries;
using ZenBlog.Application.Features.Users.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Users.Handlers
{
    public class GetUserByIdQueryHandler(UserManager<AppUser> _userManager, IMapper _mapper) :
        IRequestHandler<GetUserByIdQuery, BaseResult<GetUserByIdQueryResult>>
    {
        public async Task<BaseResult<GetUserByIdQueryResult>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user is null)
            {
                return BaseResult<GetUserByIdQueryResult>.NotFound("User Not Found");
            }
            var response = _mapper.Map<GetUserByIdQueryResult>(user);
            return BaseResult<GetUserByIdQueryResult>.Success(response);
        }
    }
}
