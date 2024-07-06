using ControleFinanceiro.Dominio.Entidades;
using ControleFinanceiro.Servicos.EntidadeServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servicos.Interfaces
{
    public interface IServicoDemonstrativoFinanceiro
    {
        Task AdicionarSalvar(DemonstrativoFinanceiroVO demonstrativoFinanceiroVO);
        Task<IEnumerable<DemonstrativoFinanceiroVO>> ObterTodos();
        Task<DemonstrativoFinanceiroVO> ObterPorID(Guid Id);
        Task<DemonstrativoFinanceiroVO> Atualizar(DemonstrativoFinanceiroVO demonstrativoFinanceiroVO);
        Task StatusDeletado(Guid Id);
        Task<IEnumerable<DemonstrativoFinanceiroVO>> RelatorioGeralDespesa();

    }
}
