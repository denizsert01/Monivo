using FluentValidation;

namespace Monivo.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommandValidator
       : AbstractValidator<CreateTransactionCommand>
    {
        public CreateTransactionCommandValidator()
        {
            RuleFor(x => x.CategoryId)
                .GreaterThan(0)
                .WithMessage("Please select a category.");

            RuleFor(x => x.Amount)
                .GreaterThan(0)
                .WithMessage("Amount must be greater than zero.");

            RuleFor(x => x.TransactionDate)
                .NotEmpty()
                .WithMessage("Transaction date is required.");

            RuleFor(x => x.Description)
                .MaximumLength(250)
                .WithMessage("Description cannot exceed 250 characters.");
        }
    }
}
