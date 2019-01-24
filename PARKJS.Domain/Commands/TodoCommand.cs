using PARKJS.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.Commands
{
    public abstract class TodoCommand : Command
    {
        /// <summary>
        /// TodoCommand 에 대한 고유 ID
        /// </summary>
        public Guid Id { get; protected set; }

        public int Seq { get; protected set; }

        public string Description { get; protected set; }

        public string Title { get; protected set; }

        public DateTime UpdateDate { get; protected set; }
    }
}
