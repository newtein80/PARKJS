using PARKJS.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.Validations
{
    public class UpdateTodoCommandValidation : TodoValidation<UpdateTodoCommand>
    {
        public UpdateTodoCommandValidation()
        {
            ValidateId();
            ValidateSeq();
            ValidateTitle();
            ValidateDescription();
            ValidateUpdateDate();
        }
    }
}
