﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PARKJS.Domain.Core.Notifications
{
    // DomainNotification 클래스에 대한 handler
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            // DomainNotification 리스트에 등록
            _notifications.Add(message);

            return Task.CompletedTask;
        }

        public virtual List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public virtual bool HasNotifications()
        {
            // DomainNotification 이 있을경우 true 반환
            return GetNotifications().Any();
        }

        // DomainNotification 초기화
        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}

/*
public class NewUser : INotification  
{  
    public string Username { get; set; }  
    public string Password { get; set; }  
} 


public class NewUserHandler : INotificationHandler<NewUser>  
{  
    public Task Handle(NewUser notification, CancellationToken cancellationToken)  
    {  
        //Save to log  
        Debug.WriteLine(" ****  Save user in database  *****");  
        return Task.FromResult(true);  
    }  
}


public class EmailHandler : INotificationHandler<NewUser>  
{  
    public Task Handle(NewUser notification, CancellationToken cancellationToken)  
    {  
        //Send email  
        Debug.WriteLine(" ****  Email sent to user  *****");  
        return Task.FromResult(true);  
    }  
}  


public class LogHandler : INotificationHandler<NewUser>  
{  
    public Task Handle(NewUser notification, CancellationToken cancellationToken)  
    {  
        //Save to log  
        Debug.WriteLine(" ****  User save to log  *****");  
        return Task.FromResult(true);  
    }  
}


public class AccountsController : Controller  
{  
    private readonly IMediator _mediator;  
    public AccountsController(IMediator mediator)  
    {  
        _mediator = mediator;  
    }  

    [HttpGet]  
    public ActionResult Login()  
    {  
        return View();  
    }  

    [HttpGet]  
    public ActionResult Register()  
    {  
        return View();  
    }  
  
    [HttpPost]  
    public ActionResult Register(NewUser user)  
    {  
        _mediator.Publish(user);  
        return RedirectToAction("Login");  
    }  
}

 * 
 * 
 * 
 * */
