using PARKJS.Domain.Core.Commands;
using PARKJS.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PARKJS.Domain.Core.Bus
{
    /// <summary>
    /// Event 와 Command 를 관리하는 Handler 를 정의한 Interface
    /// </summary>
    public interface IMediatorHandler
    {
        // https://docs.microsoft.com/ko-kr/dotnet/csharp/language-reference/keywords/where-generic-type-constraint
        /// <summary>
        /// Command (: Message(: IRequest)) 클래스에 제약조건이 걸린 Method
        /// </summary>
        /// <typeparam name="T">Command Class 의 Generic Type</typeparam>
        /// <param name="command">Command 클래스</param>
        /// <returns>Task</returns>
        Task SendCommand<T>(T command) where T : Command;

        /// <summary>
        /// Event (: Message(: IRequest) 와 INotification) 클래스에 제약조건이 걸린 Method
        /// </summary>
        /// <typeparam name="T">Event Class 의 Generic Type</typeparam>
        /// <param name="event">Event</param>
        /// <returns></returns>
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
