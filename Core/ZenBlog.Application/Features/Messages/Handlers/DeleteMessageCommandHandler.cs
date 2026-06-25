using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class DeleteMessageCommandHandler(IRepository<Message> _repository, IUnitOfWork _unitOfWork) :
        IRequestHandler<DeleteMessageCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await _repository.GetByIdAsync(request.Id);
            if (message == null)
            {
                return BaseResult<bool>.NotFound("Message not found");
            }
            _repository.Delete(message);
            var response = await _unitOfWork.SaveChangesAsync();
            return response ? BaseResult<bool>.Success(response) : BaseResult<bool>.Fail("Message couldn't be deleted");
        }
    }
}
