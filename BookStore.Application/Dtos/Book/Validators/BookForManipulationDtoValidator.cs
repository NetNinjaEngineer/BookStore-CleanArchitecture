using BookStore.Application.Helpers;
using FluentValidation;

namespace BookStore.Application.Dtos.Book.Validators;
public class BookForManipulationDtoValidator
    : AbstractValidator<BookForManipulationDto>
{
    public BookForManipulationDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotNull().WithMessage("Title can not be null")
            .MaximumLength(128).WithMessage("The Maximum lenght should be 128 characters.");

        RuleFor(x => x.PublicationYear)
            .NotNull().WithMessage("PublicationYear is Required.");

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is Required.")
            .GreaterThan(0).WithMessage("Price must be greater than 0.");

        RuleFor(x => x.Image)
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
