using AutoMapper;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Application.Features.Socials.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Mappings
{
    public class SocialMapping : Profile
    {
        public SocialMapping()
        {
            CreateMap<Social, GetSocialQueryResult>().ReverseMap();
            CreateMap<Social, CreateSocialCommand>().ReverseMap();
            CreateMap<Social, GetSocialByIdQueryResult>().ReverseMap();
            CreateMap<Social, UpdateSocialCommand>().ReverseMap();
        }
    }
}
