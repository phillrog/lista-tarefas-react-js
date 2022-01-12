namespace ListaTarefas.Core.Communication
{
    public class ResponseResult
    {
        public int Status { get; set; }
        public string Message { get; set; }        
    }

    public class QueryResult { }

    public class ResponseQueryResult
    {
        public List<QueryResult> Data { get; set; }
        public ResponseQueryResult()
        {
            Data = new List<QueryResult>();
        }
    }
}