using AutoMapper;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Application.Features.Comments.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Mappings
{
    public class CommentMapping : Profile
    {
        public CommentMapping()
        {
            CreateMap<Comment, GetCommentQueryResult>()
                .ForMember(d => d.CommentDate, o => o.MapFrom(s => s.Date))
                .ForMember(d => d.BlogTitle, o => o.MapFrom(s => s.Blog.Title));
            CreateMap<Comment, CreateCommentCommand>().ReverseMap();
            CreateMap<Comment, GetCommentByIdQueryResult>()
                .ForMember(d => d.CommentDate, o => o.MapFrom(s => s.Date));
            CreateMap<Comment, UpdateCommentCommand>().ReverseMap();
        }
    }
}
