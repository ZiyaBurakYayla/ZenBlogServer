using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Handlers
{
    public class UpdateCommentCommandHandler(IRepository<Comment> _repository, IUnitOfWork _unitOfWork, IMapper _mapper) :
        IRequestHandler<UpdateCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Comment>(request);
            _repository.Update(value);
            var result = await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(result);
        }
    }
}
