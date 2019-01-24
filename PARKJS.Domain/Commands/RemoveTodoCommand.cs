using PARKJS.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.Commands
{
    public class RemoveTodoCommand : TodoCommand
    {
        public RemoveTodoCommand(Guid id, int seq)
        {
            Id = id;
            Seq = seq;
        }

        public override bool IsValid()//abstract class Command 에 정의되어 있음
        {
            //throw new NotImplementedException();

            //abstract class Command 에 미리 선언되어 있음
            ValidationResult = new RemoveTodoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
