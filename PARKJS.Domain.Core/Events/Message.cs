using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

// 시스템의 모든 요청에 ​​대해 고유 한 메시지와 처리기를 사용하여 CQRS 아키텍처로 아키텍처를 구성하는 데 도움
// https://github.com/jbogard/MediatR/wiki
// https://ardalis.com/using-mediatr-in-aspnet-core-apps
// https://remibou.github.io/Using-Mediatr-on-ASPNET-Core-2.1-Week-25/
// https://codeopinion.com/thin-controllers-cqrs-mediatr/
// 설명이 제일 잘되어 있음 : https://www.c-sharpcorner.com/article/command-mediator-pattern-in-asp-net-core-using-mediatr2/
// 설명이 제일 더 잘되어 있음 : https://ardalis.com/using-mediatr-in-aspnet-core-apps

namespace PARKJS.Domain.Core.Events
{
    // 추상클래스
    // Message 클래스에 대한 request 요청 처리기 이며, 반환형은 없음 (반환형이 있을 경우 IRequest<반환형> 으로 표현) 
    // Message 클래스를 상속받은 자식 클래스에 대한 요청을 MediatR 에 보내서 요청에 대한 작업을 수행할 수 있다.
    /// <summary>
    /// MediatR 로 관리하는 Message 클래스 : IRequest(MediatR) 상속받음
    /// </summary>
    public abstract class Message : IRequest
    {
        /// <summary>
        /// 메시지 타입??
        /// </summary>
        public string MessageType { get; protected set; }

        /// <summary>
        /// 집합체 ID ??
        /// </summary>
        public Guid AggregateId { get; protected set; }

        /// <summary>
        /// 생성자
        /// </summary>
        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}

/*
public class NewUser: IRequest<bool>  
{  
    public string Username { get; set; }  
    public string Password { get; set; }          
}  


public class NewUserHandler : IRequestHandler<NewUser, bool>  
{         
    public Task<bool> Handle(NewUser request, CancellationToken cancellationToken)  
    {  
        // save to database  
        return Task.FromResult(true);  
    }  
}  


public class HomeController : Controller  
{  
    private readonly IMediator _mediator;  
  
    public HomeController(IMediator mediator)  
    {  
        _mediator = mediator;  
    }

    [HttpGet]  
    public ActionResult Register()  
    {  
        return View();  
    }  
  
    [HttpPost]  
    public ActionResult Register(NewUser user)  
    {  
        bool result = _mediator.Send(user).Result;  
  
        if (result)  
            return RedirectToAction("Login");  
              
        return View();  
    }  
}

 * 
 * */
