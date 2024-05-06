using BookStore.Application.Helpers;
using FluentValidation;

namespace BookStore.Application.Dtos.Book.Validators;
public class BookImageForUpdateDtoValidator
    : AbstractValidator<BookImageForUpdateDto>
{
    public BookImageForUpdateDtoValidator()
    {
        RuleFor(x => x.ImageToUpload)
         .NotNull().WithMessage("Image is Required.")
        .Must((file) =>
        {
            var fileExtension = Path.GetExtension(file!.FileName);
            if (!Constants.imageExtensions.Contains(fileExtension))
                return false;

            return true;
        }).WithMessage("Invalid image format.");
    }
}
