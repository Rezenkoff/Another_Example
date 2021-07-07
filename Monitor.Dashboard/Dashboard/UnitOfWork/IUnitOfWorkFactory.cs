using Monitor.DAL.Interfaces;

namespace Monitor.Dashboard.Monitoring.UnitOfWork
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
