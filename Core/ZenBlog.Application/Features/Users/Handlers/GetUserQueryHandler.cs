using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Queries;
using ZenBlog.Application.Features.Users.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Users.Handlers
{
    public class GetUserQueryHandler(UserManager<AppUser> _userManager, IMapper _mapper) :
        IRequestHandler<GetUserQuery, BaseResult<List<GetUserQueryResult>>>
    {
        public async Task<BaseResult<List<GetUserQueryResult>>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.ToList();
            var response = _mapper.Map<List<GetUserQueryResult>>(users);
            return BaseResult<List<GetUserQueryResult>>.Success(response);
        }
    }
}
