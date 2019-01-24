using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.Commands
{
    public class UpdateTodoCommand : TodoCommand
    {
        public UpdateTodoCommand(Guid id, int seq, string title, string description, DateTime updateDate)
        {
            Id = id;
            Seq = seq;
            Title = title;
            Description = description;
            UpdateDate = updateDate;
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
