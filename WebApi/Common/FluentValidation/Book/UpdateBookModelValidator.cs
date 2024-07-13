using FluentValidation;
using WebApi.BookOperations.UpdateBook;

namespace WebApi.Common.FluentValidation.Book
{
    public class UpdateBookModelValidator : AbstractValidator<UpdateBookModel>
    {
        public UpdateBookModelValidator()
        {
            RuleFor(x => x.Title)
                .NotNull().WithMessage("Title alanı boş olamaz")
                .NotEmpty().WithMessage("Title alanı boş olamaz")
                .MinimumLength(4).WithMessage("Titleen az 4 karakter olmalıdır");

            RuleFor(x => x.GenreId)
                .NotNull().WithMessage("GenreId alanı boş olamaz")
                .NotEmpty().WithMessage("GenreId alanı boş olamaz")
                .GreaterThan(0).WithMessage("GenreId değeri sıfırdan büyük olmalıdır");


        }
    }
}
