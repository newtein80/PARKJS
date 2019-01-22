using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
