using PARKJS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.Interfaces
{
    public interface ITodoRepository : IRepository<Todo>
    {
        Todo GetbySeq(int seq);
    }
}
