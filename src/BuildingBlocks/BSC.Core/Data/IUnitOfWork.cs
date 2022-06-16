namespace BSC.Core.Data;

public interface IUnitOfWork
{
    Task<bool> Commit();
}