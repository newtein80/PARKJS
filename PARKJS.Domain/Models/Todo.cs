using PARKJS.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.Models
{
    public class Todo : Entity
    {
        public Todo(Guid id, int seq, string description, string title, DateTime updateDate)
        {
            Id = id;//Entity.Guid
            Seq = seq;//PrimaryKey????
            Description = description;
            Title = title;
            UpdateDate = updateDate;
        }

        // Empty constructor for EF
        protected Todo()
        {
        }

        public int Seq { get; private set; }

        public string Description { get; private set; }

        public string Title { get; private set; }

        public DateTime UpdateDate { get; private set; }
    }
}
