using PARKJS.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.Validations
{
    public class RegistNewTodoCommandValidation : TodoValidation<RegistNewTodoCommand>
    {
        public RegistNewTodoCommandValidation()
        {
            ValidateTitle();
            ValidateDescription();
            ValidateUpdateDate();
        }
    }
}
