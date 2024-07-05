using ControleFinanceiro.Servicos.EntidadeServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servicos.Interfaces
{
    public interface IServicoDespesa
    {
        Task AdicionarSalvar(DespesaVO despesaVO);
        Task<IEnumerable<DespesaVO>> ObterTodos();
        Task<DespesaVO> ObterPorID(Guid Id);
        Task<DespesaVO> Atualizar(DespesaVO despesaVO);
        Task StatusDeletado(Guid Id);
        Task<IEnumerable<DespesaVO>> RelatorioGeralDespesa();
    }
}
