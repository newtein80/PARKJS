using PARKJS.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.Core.Notifications
{
    // Event 클래스를 상속받아서 Event 발생에 대한 상세 속성 클래스 ?????????????
    /// <summary>
    /// Event(: Message(: IRequest), INotification)클래스를 상속받아서 Event 발생에 대한 상세 속성 클래스 ?????????????
    /// </summary>
    public class DomainNotification : Event
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

        public abstract class Event : Message, INotification
        {
            

            public DateTime Timestamp { get; private set; }

            protected Event()
            {
                Timestamp = DateTime.Now;
            }
        }
         * 
         * */
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }

        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
        }
    }
}

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
