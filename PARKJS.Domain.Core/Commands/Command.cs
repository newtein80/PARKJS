using PARKJS.Domain.Core.Events;
using System;
using System.Collections.Generic;
// https://fluentvalidation.net/
using FluentValidation.Results;
using System.Text;

namespace PARKJS.Domain.Core.Commands
{
    // Event 클래스와는 다름 (Event : Message)
    /// <summary>
    /// Message(: IRequest)를 상속받은 클래스.
    /// </summary>
    public abstract class Command : Message
    {
        /*
         * 
        public abstract class Message : IRequest
        {
            public string MessageType { get; protected set; }
            public Guid AggregateId { get; protected set; }

            protected Message()
            {
                MessageType = GetType().Name;
            }
        }
         * 
         * */
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}

/*

using FluentValidation;

public class CustomerValidator: AbstractValidator<Customer> {
  public CustomerValidator() {
    RuleFor(x => x.Surname).NotEmpty();
    RuleFor(x => x.Forename).NotEmpty().WithMessage("Please specify a first name");
    RuleFor(x => x.Discount).NotEqual(0).When(x => x.HasDiscount);
    RuleFor(x => x.Address).Length(20, 250);
    RuleFor(x => x.Postcode).Must(BeAValidPostcode).WithMessage("Please specify a valid postcode");
  }

  private bool BeAValidPostcode(string postcode) {
    // custom postcode validating logic goes here
  }
}



var customer = new Customer();
var validator = new CustomerValidator();
ValidationResult results = validator.Validate(customer);

bool success = results.IsValid;
IList<ValidationFailure> failures = results.Errors;




public abstract class Event : Message, INotification
{
    public DateTime Timestamp { get; private set; }

    protected Event()
    {
        Timestamp = DateTime.Now;
    }
}


public abstract class Message : IRequest
{
    public string MessageType { get; protected set; }
    public Guid AggregateId { get; protected set; }

    protected Message()
    {
        MessageType = GetType().Name;
    }
}

 * 
 * */
