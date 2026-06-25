using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.ContactInfos.Result
{
    public class GetContactInfoQueryResult : BaseDto
    {
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MapUrl { get; set; }
    }
}
