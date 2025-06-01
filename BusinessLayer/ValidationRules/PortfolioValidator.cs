using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator:AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Proje adı boş bırakılamaz.")
            .MaximumLength(100).WithMessage("Proje adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Küçük resim URL'si boş bırakılamaz.");

            RuleFor(x => x.ImageUrl2)
                .NotEmpty().WithMessage("Büyük resim URL'si boş bırakılamaz.");

            RuleFor(x => x.ProjectUrl)
                .NotEmpty().WithMessage("Proje URL'si boş bırakılamaz.");

            RuleFor(x => x.ProjectValue)
                .NotEmpty().WithMessage("Proje değeri boş bırakılamaz.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Tarih bilgisi boş bırakılamaz.");

            RuleFor(x => x.IconUrl)
                .NotEmpty().WithMessage("İkon URL'si boş bırakılamaz.");
        }
    }
}