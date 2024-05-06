using FluentValidation;

namespace BookStore.Application.Dtos.Book.Validators;
public class BookForCreationDtoValidator : AbstractValidator<BookForCreationDto>
{
    public BookForCreationDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotNull().WithMessage("Title can not be null")
            .MaximumLength(128).WithMessage("The Maximum lenght should be 128 characters.");

        RuleFor(x => x.PublicationYear)
            .NotNull().WithMessage("PublicationYear is Required.");

        RuleFor(x => x.Price)
            .NotNull().WithMessage("Price is Required.");

        RuleFor(x => x.Image)
            .NotNull().WithMessage("Image is Required.")
           .Must((file) =>
           {
               List<string> imageExtensions = [
                   ".jpg",".jpeg",".png",".gif",".bmp",".tiff",".tif",
                   ".webp",".svg",".ico",".heic",".heif",".jfif"];

               var fileExtension = Path.GetExtension(file.FileName);
               if (!imageExtensions.Contains(fileExtension))
                   return false;

               return true;
           }).WithMessage("Invalid image format.");

        RuleFor(dto => dto.GenreId)
          .NotEmpty().WithMessage("GenreId is required.")
          .GreaterThan(0).WithMessage("GenreId must be greater than 0.");

        RuleFor(dto => dto.AuthorId)
            .NotEmpty().WithMessage("AuthorId is required.")
            .GreaterThan(0).WithMessage("AuthorId must be greater than 0.");

    }
}
