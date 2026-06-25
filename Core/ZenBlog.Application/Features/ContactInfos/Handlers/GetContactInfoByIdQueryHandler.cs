using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Queries;
using ZenBlog.Application.Features.ContactInfos.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers
{
    public class GetContactInfoByIdQueryHandler(IRepository<ContactInfo> _repository, IMapper _mapper) :
        IRequestHandler<GetContactInfoByIdQuery, BaseResult<GetContactInfoByIdQueryResult>>
    {
        public async Task<BaseResult<GetContactInfoByIdQueryResult>> Handle(GetContactInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var contactInfo = await _repository.GetByIdAsync(request.Id);
            if (contactInfo is null)
            {
                return BaseResult<GetContactInfoByIdQueryResult>.NotFound("ContactInfo Not Found");
            }
            var response = _mapper.Map<GetContactInfoByIdQueryResult>(contactInfo);
            return BaseResult<GetContactInfoByIdQueryResult>.Success(response);
        }
    }
}
