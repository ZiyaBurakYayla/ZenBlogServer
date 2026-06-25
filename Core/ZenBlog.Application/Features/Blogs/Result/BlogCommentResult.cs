namespace ZenBlog.Application.Features.Blogs.Result
{
    public class BlogCommentResult
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Body { get; set; }
        public DateTime CommentDate { get; set; }
        public List<BlogSubCommentResult> SubComments { get; set; }
    }
}
