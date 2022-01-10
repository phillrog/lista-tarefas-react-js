namespace ListaTarefas.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
