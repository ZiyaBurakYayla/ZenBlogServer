using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.SubComments.Result
{
    public class GetSubCommentQueryResult : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public Guid CommentId { get; set; }
    }
}
