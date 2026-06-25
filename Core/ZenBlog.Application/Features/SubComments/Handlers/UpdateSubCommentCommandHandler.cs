using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers
{
    public class UpdateSubCommentCommandHandler(IRepository<SubComment> _repository, IUnitOfWork _unitOfWork, IMapper _mapper) :
        IRequestHandler<UpdateSubCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateSubCommentCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<SubComment>(request);
            _repository.Update(value);
            var result = await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(result);
        }
    }
}
