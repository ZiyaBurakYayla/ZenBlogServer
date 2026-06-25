using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    public class UpdateSocialCommandHandler(IRepository<Social> _repository, IUnitOfWork _unitOfWork, IMapper _mapper) :
        IRequestHandler<UpdateSocialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateSocialCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Social>(request);
            _repository.Update(value);
            var result = await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(result);
        }
    }
}
