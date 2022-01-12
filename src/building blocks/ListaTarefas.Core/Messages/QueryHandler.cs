using ListaTarefas.Core.Communication;

namespace ListaTarefas.Core.Messages
{
    public class QueryHandler
    {
        protected ResponseQueryResult ResponseQueryResult;

        protected QueryHandler()
        {
            ResponseQueryResult = new ResponseQueryResult();
        }

        protected void Adicionar(IEnumerable<QueryResult> result)
        {
            ResponseQueryResult.Data.AddRange(result);
        }        
    }
}
