namespace ListaTarefas.Core.Messages
{
    public class QueryHandler<T>
    {
        protected T ResponseQueryResult;

        protected QueryHandler()
        {
            ResponseQueryResult = (T)Activator.CreateInstance(typeof(T), null);
        }             
    }
}
