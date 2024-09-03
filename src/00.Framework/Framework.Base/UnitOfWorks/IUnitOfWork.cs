namespace Framework.Base.UnitOfWorks;

public interface IUnitOfWork
{
    Task Commit();
}
