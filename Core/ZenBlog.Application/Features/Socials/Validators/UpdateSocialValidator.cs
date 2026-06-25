using FluentValidation;
using ZenBlog.Application.Features.Socials.Commands;

namespace ZenBlog.Application.Features.Socials.Validators
{
    public class UpdateSocialValidator : AbstractValidator<UpdateSocialCommand>
    {
        public UpdateSocialValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Social id is required.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            RuleFor(x => x.Url)
                .NotEmpty().WithMessage("Url is required.");

            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("Icon is required.");
        }
    }
}
