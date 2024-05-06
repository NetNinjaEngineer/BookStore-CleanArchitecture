using FluentValidation;

namespace BookStore.Application.Dtos.Book.Validators;
public class BookForUpdateDtoValidator : AbstractValidator<BookForUpdateDto>
{
    public BookForUpdateDtoValidator()
    {
        Include(new BookForManipulationDtoValidator());
    }
}
