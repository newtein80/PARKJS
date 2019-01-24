using FluentValidation;
using PARKJS.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.Validations
{
    /// <summary>
    /// TodoCommand 에 대한 유효성 검사 추상 클래스
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class TodoValidation<T> : AbstractValidator<T> where T : TodoCommand
    {
        protected void ValidateSeq()
        {
            RuleFor(c => c.Seq)
                .NotEmpty().WithMessage("NotEmpty number")
                .GreaterThan(0).WithMessage("Seq must have 0 more number");
        }

        protected void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please enter the description !");
        }

        protected void ValidateTitle()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Please enter the Title !");
        }

        protected void ValidateUpdateDate()
        {
            RuleFor(c => c.UpdateDate)
                .NotEmpty()
                .Must(HaveMinDate)
                .WithMessage("Date invalid");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        private bool HaveMinDate(DateTime updateDate)
        {
            return updateDate > DateTime.Now;
        }
    }
}
