using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    public class DeleteSocialCommandHandler(IRepository<Social> _repository, IUnitOfWork _unitOfWork) :
        IRequestHandler<DeleteSocialCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(DeleteSocialCommand request, CancellationToken cancellationToken)
        {
            var social = await _repository.GetByIdAsync(request.Id);
            if (social == null)
            {
                return BaseResult<bool>.NotFound("Social not found");
            }
            _repository.Delete(social);
            var response = await _unitOfWork.SaveChangesAsync();
            return response ? BaseResult<bool>.Success(response) : BaseResult<bool>.Fail("Social couldn't be deleted");
        }
    }
}
