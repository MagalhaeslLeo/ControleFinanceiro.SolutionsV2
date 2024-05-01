using ControleFinanceiro.Dominio.IdBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Dominio.Interfaces
{
    public interface IRepositorioBase<T> where T : IDEntidade
    {
        Task Adicionar(T entidade);
        Task AdicionarSalvar(T entidade);
        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorID(Guid Id);
        Task<T> Atualizar(T entidade);
        Task StatusDeletado(T entidade);
    }
}
