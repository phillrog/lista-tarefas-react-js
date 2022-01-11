namespace ListaTarefas.Application.ViewModels
{
    public class EditarTarefaViewModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Vencimento { get; set; }
        public int Status { get; set; }
    }
}
