using MediatR;
using PARKJS.Domain.Commands;
using PARKJS.Domain.Core.Bus;
using PARKJS.Domain.Core.Notifications;
using PARKJS.Domain.Events;
using PARKJS.Domain.Interfaces;
using PARKJS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//https://github.com/jbogard/MediatR/wiki/Migration-Guide-4.x-to-5.0
namespace PARKJS.Domain.CommandHandlers
{
    public class TodoCommandHandler : CommandHandler,
        IRequestHandler<RegistNewTodoCommand>,
        IRequestHandler<RemoveTodoCommand>,
        IRequestHandler<UpdateTodoCommand>
    {
        private readonly ITodoRepository todoRepository;
        private readonly IMediatorHandler mediatorHandler;

        public TodoCommandHandler(
            ITodoRepository todoRepository,
            IUnitOfWork unitOfWork,
            IMediatorHandler mediatorHandler,
            INotificationHandler<DomainNotification> domainNotificationHandler) : base(unitOfWork, mediatorHandler, domainNotificationHandler)
        {
            this.todoRepository = todoRepository;
            this.mediatorHandler = mediatorHandler;
        }

        //https://github.com/jbogard/MediatR/wiki/Migration-Guide-4.x-to-5.0
        public Task<Unit> Handle(RegistNewTodoCommand iRegistNewTodoCommand, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            if(!iRegistNewTodoCommand.IsValid())
            {
                NotifyValidationErrors(iRegistNewTodoCommand);
                //return Task.CompletedTask;

                //https://github.com/jbogard/MediatR/wiki/Migration-Guide-4.x-to-5.0
                //return Unit.Value; // for async/await
                return Unit.Task; // for pure Task-based methods
            }

            var todo = new Todo(
                Guid.NewGuid(),
                iRegistNewTodoCommand.Seq,
                iRegistNewTodoCommand.Description,
                iRegistNewTodoCommand.Title,
                iRegistNewTodoCommand.UpdateDate);

            if(todoRepository.GetbySeq(todo.Seq) != null)
            {
                mediatorHandler.RaiseEvent(new DomainNotification(iRegistNewTodoCommand.MessageType, "The Todo has already been taken"));
                //return Task.CompletedTask;

                //https://github.com/jbogard/MediatR/wiki/Migration-Guide-4.x-to-5.0
                //return Unit.Value; // for async/await
                return Unit.Task; // for pure Task-based methods
            }

            todoRepository.Add(todo);

            if (Commit())
            {
                mediatorHandler.RaiseEvent(new TodoRegisteredEvent(todo.Id, todo.Seq, todo.Description, todo.Title, todo.UpdateDate));
            }

            //return Task.CompletedTask;

            //https://github.com/jbogard/MediatR/wiki/Migration-Guide-4.x-to-5.0
            //return Unit.Value; // for async/await
            return Unit.Task; // for pure Task-based methods
        }

        public Task<Unit> Handle(RemoveTodoCommand iRemoveTodoCommand, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> Handle(UpdateTodoCommand iUpdateTodoCommand, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
