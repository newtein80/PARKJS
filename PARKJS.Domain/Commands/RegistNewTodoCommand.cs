using PARKJS.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.Commands
{
    public class RegistNewTodoCommand : TodoCommand
    {
        public RegistNewTodoCommand(string title, string description, DateTime updateDate)
        {
            Title = title;
            Description = description;
            UpdateDate = updateDate;
        }

        public override bool IsValid()//abstract class Command 에 정의되어 있음
        {
            //throw new NotImplementedException();

            //abstract class Command 에 미리 선언되어 있음
            ValidationResult = new RegistNewTodoCommandValidation().Validate(this);//this = RegistNewTodoCommand
            return ValidationResult.IsValid;
        }
    }
}
