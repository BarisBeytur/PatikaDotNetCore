using FluentValidation;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.Common.FluentValidation.Book
{
    public class CreateBookModelValidator : AbstractValidator<CreateBookModel>
    {
        public CreateBookModelValidator()
        {
            RuleFor(x => x.Title)
                .NotNull().WithMessage("Title alanı boş olamaz")
                .NotEmpty().WithMessage("Title alanı boş olamaz")
                .MinimumLength(4).WithMessage("Title en az 4 karakter olmalıdır");

            RuleFor(x => x.GenreId)
                .NotNull().WithMessage("GenreId alanı boş olamaz")
                .NotEmpty().WithMessage("GenreId alanı boş olamaz")
                .GreaterThan(0).WithMessage("GenreId değeri sıfırdan büyük olmalıdır");

            RuleFor(x => x.PageCount)
                .NotNull().WithMessage("PageCount alanı boş olamaz")
                .NotEmpty().WithMessage("PageCount alanı boş olamaz")
                .GreaterThan(0).WithMessage("PageCount alanı sıfırdan büyük olmalıdır");


            RuleFor(x => x.PublishDate.Date)
                .NotEmpty().WithMessage("PublishDate alanı boş olamaz")
                .LessThan(System.DateTime.Now.Date).WithMessage("PublishDate, bugünden eski olmalıdır");
        }
    }
}
