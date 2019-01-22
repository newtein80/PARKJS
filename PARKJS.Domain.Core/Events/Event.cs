using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

// Message.cs 를 참고하면 MediatR 에 대한 설명 링크가 있음
namespace PARKJS.Domain.Core.Events
{
    // Message 는 왜 받았을까??? Message와 Event는.. Event는 INotification 과 IRequest 모두 상속, 단 Message는 IRequest만 상속
    // 알림에서 예상되는 동작은 INotification을 구현하는 것으로 일부 유형을 정의하고 INotificationHandler <SomeType> 유형을 하나 이상 처리기로 정의한다는 것입니다.
    // 게시 할 때모든 핸들러가 응답으로 호출됩니다.
    /// <summary>
    /// MediatR 로 관리하는 Event 클래스 : Message(: IRequest(MediatR)) 와 INotification(MediatR) 상속받음
    /// </summary>
    public abstract class Event : Message, INotification
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

        /// <summary>
        /// Event 가 발생한 시간을 셋팅하기 위해서???
        /// </summary>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// 생성자: 객체가 생성될 때 기본으로 현재시간을 변수에 Set
        /// </summary>
        protected Event()
        {
            Timestamp = DateTime.Now;
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
