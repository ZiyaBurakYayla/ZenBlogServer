using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.SubComments.Commands
{
    public class CreateSubCommentCommand : IRequest<BaseResult<object>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Guid CommentId { get; set; }
    }
}
