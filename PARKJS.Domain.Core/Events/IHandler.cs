using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.Core.Events
{
    // Request Message 를 Handling
    // Message 클래스를 상속받은 클래스에 한해서(<- where T : Message) Handling 하는 인터페이스
    /// <summary>
    /// Message(: IRequest) 클래스를 상속받은 클래스에 한해서(where T : Message) Handling 하는 인터페이스
    /// </summary>
    /// <typeparam name="T">Inherited Class : Message Class(: IRequest)</typeparam>
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}
