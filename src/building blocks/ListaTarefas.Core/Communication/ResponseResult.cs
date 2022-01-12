namespace ListaTarefas.Core.Communication
{
    public class ResponseResult
    {
        public int Status { get; set; }
        public string Message { get; set; }        
    }

    public interface IQueryResult { }
}