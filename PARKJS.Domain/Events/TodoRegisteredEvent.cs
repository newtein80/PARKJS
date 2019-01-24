using PARKJS.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.Events
{
    public class TodoRegisteredEvent : Event
    {
        /// <summary>
        /// Regist Event 에 대한 고유 ID
        /// </summary>
        public Guid Id { get; set; }

        public int Seq { get; private set; }

        public string Description { get; private set; }

        public string Title { get; private set; }

        public DateTime UpdateDate { get; private set; }

        public TodoRegisteredEvent(Guid id, int seq, string description, string title, DateTime updateDate)
        {
            Id = id;
            Seq = seq;
            Description = description;
            Title = title;
            UpdateDate = updateDate;
            AggregateId = id;//Message Inherit
        }
    }
}
