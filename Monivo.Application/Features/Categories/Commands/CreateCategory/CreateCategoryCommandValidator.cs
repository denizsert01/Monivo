using FluentValidation;

namespace Monivo.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(50).WithMessage("Category name cannot exceed 50 characters.")
                .MinimumLength(2).WithMessage("Category name cannot be less than 2 characters.");
            RuleFor(x => x.TypeParameterId)
                .GreaterThan(0)
    .           WithMessage("Category type is required.");
            RuleFor(x => x.UserId)
    .GreaterThan(0)
    .WithMessage("User is required.");
        }
    }
}
