using BookstoreManager.Contracts.Requests;
using FluentValidation;

namespace BookstoreManager.UseCases.SharedValidator;

// TODO: - Add rule that verifies if there will be no duplicate title and author

public class RequestBookValidator : AbstractValidator<CreateBookRequest>
{
        public RequestBookValidator()
        {
            RuleFor(book => book.Title)
                .NotEmpty().WithMessage("Book title is required.")
                .MinimumLength(2).WithMessage("Book title must have at least 2 characters.")
                .MaximumLength(120).WithMessage("Book title must not exceed 120 characters.");

            RuleFor(book => book.Author)
                .NotEmpty().WithMessage("Book author is required.")
                .MinimumLength(2).WithMessage("Book author must have at least 2 characters.")
                .MaximumLength(120).WithMessage("Book author must not exceed 120 characters.");

            RuleFor(book => book.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Book price must be greater than or equal to zero.");

            RuleFor(book => book.Stock)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Book stock must be greater than or equal to zero.");

            RuleFor(book => book.Genre)
                .IsInEnum()
                .WithMessage("Invalid book genre.");
        }
}
