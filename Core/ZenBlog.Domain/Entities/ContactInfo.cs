using ZenBlog.Domain.Entities.Common;

namespace ZenBlog.Domain.Entities;

public class ContactInfo : BaseEntity
{
    public string Adress { get; set; }
    public string Email { get; set; }
    public string PhoneNo { get; set; }
    public string MapUrl { get; set; }
}
