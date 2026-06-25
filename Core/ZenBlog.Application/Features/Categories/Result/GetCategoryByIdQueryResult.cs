using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Blogs.Result;

namespace ZenBlog.Application.Features.Categories.Result
{
    public class GetCategoryByIdQueryResult :BaseDto
    {
        public string CategoryName { get; set; }
        public IList<GetBlogQueryResult> Blogs { get; set; }
    }
}
