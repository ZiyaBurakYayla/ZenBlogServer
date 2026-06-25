using AutoMapper;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Mappings
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<Blog,GetBlogQueryResult>().ReverseMap();
            CreateMap<Blog,CreateBlogCommand>().ReverseMap();
            CreateMap<Blog,GetBlogByIdQueryResult>().ReverseMap();
            CreateMap<Blog,UpdateBlogCommand>().ReverseMap();
            CreateMap<Blog, GetBlogsByCategoryIdQueryResult>().ReverseMap();

            CreateMap<Comment, BlogCommentResult>()
                .ForMember(d => d.CommentDate, o => o.MapFrom(s => s.Date));

            CreateMap<SubComment, BlogSubCommentResult>()
                .ForMember(d => d.CommentDate, o => o.MapFrom(s => s.Date));
        }
    }
}
