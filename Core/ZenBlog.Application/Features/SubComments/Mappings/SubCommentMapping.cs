using AutoMapper;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Application.Features.SubComments.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Mappings
{
    public class SubCommentMapping : Profile
    {
        public SubCommentMapping()
        {
            CreateMap<SubComment, GetSubCommentQueryResult>().ReverseMap();
            CreateMap<SubComment, CreateSubCommentCommand>().ReverseMap();
            CreateMap<SubComment, GetSubCommentByIdQueryResult>().ReverseMap();
            CreateMap<SubComment, UpdateSubCommentCommand>().ReverseMap();
        }
    }
}
