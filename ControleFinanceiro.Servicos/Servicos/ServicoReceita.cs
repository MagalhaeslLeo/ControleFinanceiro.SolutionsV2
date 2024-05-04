using ControleFinanceiro.Servicos.EntidadeServico;
using ControleFinanceiro.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servicos.Servicos
{
    public class ServicoReceita : IServicoReceita
    {
        public Task<ReceitaVO> AdicionarSalvar(ReceitaVO receitaVO)
        {
            throw new NotImplementedException();
        }

        public Task<ReceitaVO> Atualizar(ReceitaVO receitaVO)
        {
            throw new NotImplementedException();
        }

        public Task<ReceitaVO> ObterPorID(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReceitaVO>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task StatusDeletado(ReceitaVO receitaVO)
        {
            throw new NotImplementedException();
        }
    }
}
