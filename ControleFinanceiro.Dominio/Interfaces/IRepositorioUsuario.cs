using ControleFinanceiro.Dominio.Entidades;

namespace ControleFinanceiro.Dominio.Interfaces
{
    public interface IRepositorioUsuario : IRepositorioBase<Usuario>
    {
        Task<Usuario> ObterUsuarioPorEmailSenha(string email, string senha);
    }
}
