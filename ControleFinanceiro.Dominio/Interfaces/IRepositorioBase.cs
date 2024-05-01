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
        IQueryable<T> Queryable();
        Task Commit();
        void Adicionar(T entidade);
        Task<T> AdicionarSalvar(T entidade);
        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorID(Guid Id);
        Task<T> Atualizar(T entidade);
        Task StatusDeletado(T entidade);
    }
}
