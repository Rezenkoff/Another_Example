using Monitor.DAL.Interfaces;
using System;
using System.Data;

namespace Monitor.DAL.UnitOfWork
{
    public class AdoNetUnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public AdoNetUnitOfWork(IDbConnection connection)
        {
            _connection = connection;
            _transaction = connection.BeginTransaction();
        }

        public IDbCommand CreateCommand()
        {
            var command = _connection.CreateCommand();
            command.CommandTimeout = 3600;
            command.Transaction = _transaction;
            return command;
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction = null;
            }

            if (_connection != null)
            {
                _connection.Close();
                _connection = null;
            }
        }

        public void SaveChanges()
        {
            if (_transaction == null)
                throw new InvalidOperationException
                 ("Transaction have already been committed. Check your transaction handling.");

            _transaction.Commit();
            _transaction = null;
        }
    }
}
