using PARKJS.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.Events
{
    public class TodoRemovedEvent : Event
    {
        /// <summary>
        /// Remove Event 에 대한 고유 ID
        /// </summary>
        public Guid Id { get; set; }

        public TodoRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
