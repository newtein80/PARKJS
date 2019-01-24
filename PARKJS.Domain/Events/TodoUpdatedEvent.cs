using PARKJS.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.Events
{
    public class TodoUpdatedEvent : Event
    {
        /// <summary>
        /// Update Event 에 대한 고유 ID
        /// </summary>
        public Guid Id { get; set; }

        public int Seq { get; private set; }

        public string Description { get; private set; }

        public string Title { get; private set; }

        public DateTime UpdateDate { get; private set; }

        public TodoUpdatedEvent(Guid id, int seq, string description, string title, DateTime updateDate)
        {
            Id = id;
            Seq = seq;
            Description = description;
            Title = title;
            UpdateDate = updateDate;
            AggregateId = id;
        }
    }
}
