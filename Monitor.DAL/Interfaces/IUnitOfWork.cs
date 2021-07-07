using System;
using System.Data;

namespace Monitor.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDbCommand CreateCommand();
        void SaveChanges();
    }
}
