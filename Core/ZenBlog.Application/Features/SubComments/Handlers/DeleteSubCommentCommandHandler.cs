using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers
{
    public class DeleteSubCommentCommandHandler(IRepository<SubComment> _repository, IUnitOfWork _unitOfWork) :
        IRequestHandler<DeleteSubCommentCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(DeleteSubCommentCommand request, CancellationToken cancellationToken)
        {
            var subComment = await _repository.GetByIdAsync(request.Id);
            if (subComment == null)
            {
                return BaseResult<bool>.NotFound("SubComment not found");
            }
            _repository.Delete(subComment);
            var response = await _unitOfWork.SaveChangesAsync();
            return response ? BaseResult<bool>.Success(response) : BaseResult<bool>.Fail("SubComment couldn't be deleted");
        }
    }
}
