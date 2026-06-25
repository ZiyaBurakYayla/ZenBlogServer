using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Handlers
{
    public class UpdateCategoryCommandHandler(IRepository<Category> _repository, IUnitOfWork _unitOfWork, IMapper _mapper) :
        IRequestHandler<UpdateCategoryCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Category>(request);
            _repository.Update(value);
            var result = await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(result);
        }
    }
}
