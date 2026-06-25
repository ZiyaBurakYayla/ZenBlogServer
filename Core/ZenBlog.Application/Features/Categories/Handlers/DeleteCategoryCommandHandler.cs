using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Handlers
{
    public class DeleteCategoryCommandHandler(IRepository<Category> _repository, IUnitOfWork _unitOfWork) : 
        IRequestHandler<DeleteCategoryCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);
            if (category == null)
            {
                return BaseResult<bool>.NotFound("Category not found");
            }
            _repository.Delete(category);
            var response = await _unitOfWork.SaveChangesAsync();
            return response ? BaseResult<bool>.Success(response) : BaseResult<bool>.Fail("Category couldn't be deleted");
        }
    }
}
