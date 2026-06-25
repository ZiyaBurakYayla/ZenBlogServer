using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handllers
{
    public class DeleteBlogCommandHandler(IRepository<Blog> _repository , IUnitOfWork _unitOfWork) : 
        IRequestHandler<DeleteBlogCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id);
            if (blog == null)
            {
                return BaseResult<object>.NotFound("Blog Not Found");
            }
            _repository.Delete(blog);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Blog Deleted");
        }
    }
}
