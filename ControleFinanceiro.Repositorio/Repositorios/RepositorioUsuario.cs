using ControleFinanceiro.Dominio.Entidades;
using ControleFinanceiro.Dominio.Interfaces;
using ControleFinanceiro.Repositorio.ContextoDB;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Repositorio.Repositorios
{
    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(Contexto contexto) : base(contexto) { }

        public async Task<Usuario> ObterUsuarioPorEmailSenha(string email, string senha)
        {
            //Variável que receberá consulta SQL
            var query = @"select 
                          Id,
                          NomeUsuario,
                          EmailUsuario,
                          SenhaUsuario,
                          CreatedAt,
                          IsDeleted
                          from SEGUsuario
                          where EmailUsuario = @email and SenhaUsuario = @senha";

            //Parametros para consulta SQL
            var parametros = new[]
            {
                new SqlParameter("@email", email),
                new SqlParameter("@senha", senha)
            };

            //Executando consulta SQL com parametros
            var usuario = await contexto.Usuario.FromSqlRaw(query, parametros).FirstOrDefaultAsync();
            return usuario;
        }

    }
}
