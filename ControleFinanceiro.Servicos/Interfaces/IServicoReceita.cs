using ControleFinanceiro.Servicos.EntidadeServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servicos.Interfaces
{
    public interface IServicoReceita
    {
        Task AdicionarSalvar(ReceitaVO receitaVO);
        Task<IEnumerable<ReceitaVO>> ObterTodos();
        Task<ReceitaVO> ObterPorID(Guid Id);
        Task<ReceitaVO> Atualizar(ReceitaVO receitaVO);
        Task StatusDeletado(Guid Id);
    }
}
