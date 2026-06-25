using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers
{
    public class DeleteContactInfoCommandHandler(IRepository<ContactInfo> _repository, IUnitOfWork _unitOfWork) :
        IRequestHandler<DeleteContactInfoCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(DeleteContactInfoCommand request, CancellationToken cancellationToken)
        {
            var contactInfo = await _repository.GetByIdAsync(request.Id);
            if (contactInfo == null)
            {
                return BaseResult<bool>.NotFound("ContactInfo not found");
            }
            _repository.Delete(contactInfo);
            var response = await _unitOfWork.SaveChangesAsync();
            return response ? BaseResult<bool>.Success(response) : BaseResult<bool>.Fail("ContactInfo couldn't be deleted");
        }
    }
}
