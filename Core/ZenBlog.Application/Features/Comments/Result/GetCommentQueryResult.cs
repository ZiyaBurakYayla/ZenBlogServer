using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Comments.Result
{
    public class GetCommentQueryResult : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public DateTime CommentDate { get; set; }
        public Guid BlogId { get; set; }
        public string BlogTitle { get; set; }
    }
}
