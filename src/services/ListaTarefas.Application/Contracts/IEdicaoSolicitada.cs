using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTarefas.Application.Contracts
{
    public interface IEdicaoSolicitada
    {
        public Guid AggregateId { get; }
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Vencimento { get; set; }
        public int Status { get; set; }
        public DateTime Timestamp { get; }
        public string MessageType { get; set; }
    }
}
