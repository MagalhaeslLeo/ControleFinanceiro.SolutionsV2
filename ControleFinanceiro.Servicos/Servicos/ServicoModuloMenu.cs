using ControleFinanceiro.Servicos.EntidadeServico;
using ControleFinanceiro.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servicos.Servicos
{
    public class ServicoModuloMenu : IServicoModuloMenu
    {
        public Task<ModuloMenuVO> AdicionarSalvar(ModuloMenuVO moduloMenuVO)
        {
            throw new NotImplementedException();
        }

        public Task<ModuloMenuVO> Atualizar(ModuloMenuVO moduloMenuVO)
        {
            throw new NotImplementedException();
        }

        public Task<ModuloMenuVO> ObterPorID(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ModuloMenuVO>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task StatusDeletado(ModuloMenuVO moduloMenuVO)
        {
            throw new NotImplementedException();
        }
    }
}
