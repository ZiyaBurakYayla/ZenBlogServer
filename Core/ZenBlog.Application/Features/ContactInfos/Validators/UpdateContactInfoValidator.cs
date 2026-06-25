using FluentValidation;
using ZenBlog.Application.Features.ContactInfos.Commands;

namespace ZenBlog.Application.Features.ContactInfos.Validators
{
    public class UpdateContactInfoValidator : AbstractValidator<UpdateContactInfoCommand>
    {
        public UpdateContactInfoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ContactInfo id is required.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(250).WithMessage("Address must not exceed 250 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email address is required.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required.");

            RuleFor(x => x.MapUrl)
                .NotEmpty().WithMessage("Map url is required.");
        }
    }
}
