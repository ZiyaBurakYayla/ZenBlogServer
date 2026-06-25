using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Handlers
{
    public class DeleteCommentCommandHandler(IRepository<Comment> _repository, IUnitOfWork _unitOfWork) :
        IRequestHandler<DeleteCommentCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetByIdAsync(request.Id);
            if (comment == null)
            {
                return BaseResult<bool>.NotFound("Comment not found");
            }
            _repository.Delete(comment);
            var response = await _unitOfWork.SaveChangesAsync();
            return response ? BaseResult<bool>.Success(response) : BaseResult<bool>.Fail("Comment couldn't be deleted");
        }
    }
}
