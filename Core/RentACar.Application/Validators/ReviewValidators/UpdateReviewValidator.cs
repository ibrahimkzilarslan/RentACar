﻿using FluentValidation;
using RentACar.Application.Features.Mediator.Commands.ReviewCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Validators.ReviewValidators
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen müşteri adını boş geçmeyiniz.");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter girişi yapınız.");
            RuleFor(x => x.RatingValue).NotEmpty().WithMessage("Lütfen puan değerini boş geçmeyiniz.");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen yorum değerini boş geçmeyiniz.");
            RuleFor(x => x.Comment).MinimumLength(50).WithMessage("Lütfen yorum kısmına en az 50 karakter veri girişi yapınız.");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Lütfen yorum kısmına en fazla 50 karakter veri girişi yapınız.");
   
        }
    }
}
