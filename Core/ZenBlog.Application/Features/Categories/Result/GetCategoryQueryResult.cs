using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Result
{
    public class GetCategoryQueryResult : BaseDto
    {
        public string CategoryName { get; set; }
        public List<GetBlogQueryResult> Blogs { get; set; }
    }
}
