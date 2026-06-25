using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class CreateMessageCommandHandler(IRepository<Message> _repository, IUnitOfWork _unitOfWork, IMapper _mapper) :
        IRequestHandler<CreateMessageCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = _mapper.Map<Message>(request);
            await _repository.CreateAsync(message);
            var result = await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(message);
        }
    }
}
