using FluentValidation;

namespace Google_Docs_Clone.Models.Validations
{
    public class DocumentValidator:AbstractValidator<Document>
    {
        public DocumentValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title alanı boş geçilemez !");
            RuleFor(x => x.Title).MinimumLength(10).WithMessage("Title için en az 10 karakter girin.");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Title için en çok 50 karakter girin.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content alanı boş geçilemez !");
            RuleFor(x => x.Content).MinimumLength(100).WithMessage("Content alanı için en az 100 karakter girin.");
            RuleFor(x => x.Content).MaximumLength(8000).WithMessage("Content alanı için en fazla 8000 karakter girin.");

        }
    }
}
