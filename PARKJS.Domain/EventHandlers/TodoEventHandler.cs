using MediatR;
using PARKJS.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PARKJS.Domain.EventHandlers
{
    public class TodoEventHandler :
        INotificationHandler<TodoRegisteredEvent>,
        INotificationHandler<TodoRemovedEvent>,
        INotificationHandler<TodoUpdatedEvent>
    {
        public Task Handle(TodoRegisteredEvent eventMessage, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();

            // Send Regist Information Logic
            return Task.CompletedTask;
        }

        public Task Handle(TodoRemovedEvent eventMessage, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();

            // Send Remove Information Logic
            return Task.CompletedTask;
        }

        public Task Handle(TodoUpdatedEvent eventMessage, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();

            // Send Update information Logic
            return Task.CompletedTask;
        }
    }
}
