using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.Core.Events
{
    /// <summary>
    /// Event(: Message(: IRequest), INotification)를 상속받은 클래스
    /// </summary>
    public class StoredEvent : Event
    {
        /*

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

        public Guid Id { get; private set; }

        public string Data { get; private set; }

        public string User { get; private set; }

        // EF Constructor
        protected StoredEvent() { }

        public StoredEvent(Event theEvent, string data, string user)
        {
            Id = Guid.NewGuid();
            AggregateId = theEvent.AggregateId;//Message
            MessageType = theEvent.MessageType;//Message
            Data = data;//constructor parameter
            User = user;//constructor parameter
        }
    }
}
