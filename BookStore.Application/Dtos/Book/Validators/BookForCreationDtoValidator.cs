using FluentValidation;

namespace BookStore.Application.Dtos.Book.Validators;
public class BookForCreationDtoValidator
    : AbstractValidator<BookForCreationDto>
{
    public BookForCreationDtoValidator()
    {
        Include(new BookForManipulationDtoValidator());

        RuleFor(dto => dto.GenreId)
          .NotEmpty().WithMessage("GenreId is required.")
          .GreaterThan(0).WithMessage("GenreId must be greater than 0.");

        RuleFor(dto => dto.AuthorId)
            .NotEmpty().WithMessage("AuthorId is required.")
            .GreaterThan(0).WithMessage("AuthorId must be greater than 0.");

    }
}
