using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Command.ReviewCommands;

namespace UdemyCarBook.Application.Validators.ReviewValidator
{
    public class CreateReviewValidator:AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen Müşteri adını boş geçmeyiniz.");
            RuleFor(x => x.CustomerImage).NotEmpty().WithMessage("Lütfen Müşteri resmini boş geçmeyiniz.");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen yorum alanını boş geçmeyiniz.");
            RuleFor(x => x.Comment).MinimumLength(30).WithMessage("Lütfen yorum alanını en az 30 karakter giriniz.");
            RuleFor(x => x.RaytingValue).InclusiveBetween(1, 5).WithMessage("Değerlendirme değeri 1 ile 5 arasında olmalıdır.");
            RuleFor(x => x.CarID).GreaterThan(0).WithMessage("Lütfen geçerli bir araç ID'si giriniz.");

        }
    }
}
