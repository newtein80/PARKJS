using PARKJS.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.Validations
{
    public class RemoveTodoCommandValidation : TodoValidation<RemoveTodoCommand>
    {
        public RemoveTodoCommandValidation()
        {
            ValidateId();
            ValidateSeq();
        }
    }
}
