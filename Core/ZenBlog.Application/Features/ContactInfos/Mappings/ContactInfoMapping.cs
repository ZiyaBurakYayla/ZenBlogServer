using AutoMapper;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Application.Features.ContactInfos.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Mappings
{
    public class ContactInfoMapping : Profile
    {
        public ContactInfoMapping()
        {
            CreateMap<ContactInfo, GetContactInfoQueryResult>()
                .ForMember(d => d.Address, o => o.MapFrom(s => s.Adress))
                .ForMember(d => d.Phone, o => o.MapFrom(s => s.PhoneNo));
            CreateMap<ContactInfo, GetContactInfoByIdQueryResult>()
                .ForMember(d => d.Address, o => o.MapFrom(s => s.Adress))
                .ForMember(d => d.Phone, o => o.MapFrom(s => s.PhoneNo));
            CreateMap<CreateContactInfoCommand, ContactInfo>()
                .ForMember(d => d.Adress, o => o.MapFrom(s => s.Address))
                .ForMember(d => d.PhoneNo, o => o.MapFrom(s => s.Phone));
            CreateMap<UpdateContactInfoCommand, ContactInfo>()
                .ForMember(d => d.Adress, o => o.MapFrom(s => s.Address))
                .ForMember(d => d.PhoneNo, o => o.MapFrom(s => s.Phone));
        }
    }
}
