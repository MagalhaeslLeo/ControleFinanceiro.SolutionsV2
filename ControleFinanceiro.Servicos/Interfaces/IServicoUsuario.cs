using ControleFinanceiro.Servicos.EntidadeServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servicos.Interfaces
{
    public interface IServicoUsuario
    {
        Task AdicionarSalvar(UsuarioVO usuarioVO);
        Task<IEnumerable<UsuarioVO>> ObterTodos();
        Task<UsuarioVO> ObterPorID(Guid Id);
        Task<UsuarioVO> Atualizar(UsuarioVO usuarioVO);
        Task StatusDeletado(Guid Id);
        Task<UsuarioVO> ObterUsuarioPorEmailSenha(string email, string senha);
    }
}
