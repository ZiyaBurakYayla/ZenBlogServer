using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Queries;
using ZenBlog.Application.Features.Socials.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    public class GetSocialQueryHandler(IRepository<Social> _repository, IMapper _mapper) :
        IRequestHandler<GetSocialQuery, BaseResult<List<GetSocialQueryResult>>>
    {
        public async Task<BaseResult<List<GetSocialQueryResult>>> Handle(GetSocialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var response = _mapper.Map<List<GetSocialQueryResult>>(values);
            return BaseResult<List<GetSocialQueryResult>>.Success(response);
        }
    }
}
