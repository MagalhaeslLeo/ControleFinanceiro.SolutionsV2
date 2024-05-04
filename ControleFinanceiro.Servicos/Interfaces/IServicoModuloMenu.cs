using ControleFinanceiro.Servicos.EntidadeServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servicos.Interfaces
{
    public interface IServicoModuloMenu
    {
        Task AdicionarSalvar(ModuloMenuVO moduloMenuVO);
        Task<IEnumerable<ModuloMenuVO>> ObterTodos();
        Task<ModuloMenuVO> ObterPorID(Guid Id);
        Task<ModuloMenuVO> Atualizar(ModuloMenuVO moduloMenuVO);
        Task StatusDeletado(Guid Id);
    }
}
