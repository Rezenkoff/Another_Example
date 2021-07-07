using System;
using System.Data;

namespace Monitor.Dashboard.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDbCommand CreateCommand();
        void SaveChanges();
    }
}
