using MediatR;
using PARKJS.Domain.Core.Bus;
using PARKJS.Domain.Core.Commands;
using PARKJS.Domain.Core.Notifications;
using PARKJS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMediatorHandler mediatorHandler;//Command = Send, Event = Raise
        private readonly DomainNotificationHandler domainNotificationHandler;

        public CommandHandler(IUnitOfWork unitOfWork, IMediatorHandler mediatorHandler, INotificationHandler<DomainNotification> domainNotificationHandler)
        {
            this.unitOfWork = unitOfWork;
            this.mediatorHandler = mediatorHandler;
            this.domainNotificationHandler = (DomainNotificationHandler)domainNotificationHandler;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                mediatorHandler.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (domainNotificationHandler.HasNotifications())
            {
                return false;
            }

            if (unitOfWork.Commit())
            {
                return true;
            }

            mediatorHandler.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }
    }
}
