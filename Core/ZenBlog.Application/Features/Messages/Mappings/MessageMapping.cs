using AutoMapper;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Application.Features.Messages.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Mappings
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<Message, GetMessageQueryResult>()
                .ForMember(d => d.MessageBody, o => o.MapFrom(s => s.Comment));
            CreateMap<Message, GetMessageByIdQueryResult>()
                .ForMember(d => d.MessageBody, o => o.MapFrom(s => s.Comment));
            CreateMap<CreateMessageCommand, Message>()
                .ForMember(d => d.Comment, o => o.MapFrom(s => s.MessageBody));
            CreateMap<UpdateMessageCommand, Message>()
                .ForMember(d => d.Comment, o => o.MapFrom(s => s.MessageBody));
        }
    }
}
