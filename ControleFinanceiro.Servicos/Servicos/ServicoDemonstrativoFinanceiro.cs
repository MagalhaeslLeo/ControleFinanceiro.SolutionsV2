using ControleFinanceiro.Servicos.EntidadeServico;
using ControleFinanceiro.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servicos.Servicos
{
    public class ServicoDemonstrativoFinanceiro : IServicoDemonstrativoFinanceiro
    {
        public Task AdicionarSalvar(DemonstrativoFinanceiroVO demonstrativoFinanceiroVO)
        {
            throw new NotImplementedException();
        }

        public Task<DemonstrativoFinanceiroVO> Atualizar(DemonstrativoFinanceiroVO demonstrativoFinanceiroVO)
        {
            throw new NotImplementedException();
        }

        public Task<DemonstrativoFinanceiroVO> ObterPorID(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DemonstrativoFinanceiroVO>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task StatusDeletado(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
