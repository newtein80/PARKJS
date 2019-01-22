using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.Core.Events
{
    // Event ( : Message, IRequest, INotification) 저장 메서드 정의 인터페이스
    /// <summary>
    /// Event ( : Message, IRequest, INotification) 저장 메서드 정의 인터페이스
    /// </summary>
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
