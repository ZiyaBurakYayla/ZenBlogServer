using MediatR;
using Microsoft.AspNetCore.Identity;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Users.Handlers
{
    public class DeleteUserCommandHandler(UserManager<AppUser> _userManager) :
        IRequestHandler<DeleteUserCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user is null)
            {
                return BaseResult<bool>.NotFound("User not found");
            }

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded ? BaseResult<bool>.Success(true) : BaseResult<bool>.Fail(result.Errors);
        }
    }
}
