using ControleFinanceiro.Dominio.Entidades;
using ControleFinanceiro.Dominio.Interfaces;
using ControleFinanceiro.Repositorio.ContextoDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Repositorio.Repositorios
{
    public class RepositorioDemonstrativoFinanceiro : RepositorioBase<DemonstrativoFinanceiro>,IRepositorioDemonstrativoFinanceiro
    {
        public RepositorioDemonstrativoFinanceiro(Contexto contexto) : base(contexto) 
        {

        }

        public async Task<IEnumerable<DemonstrativoFinanceiro>> RelatorioGeralDespesa()
        {
            //Variavel que receberá a consulta SQL
            var query = @"
                          SELECT 
                          desp.descricao,
                          dem.CreatedAt,
                          dem.IsDeleted,
                          dem.Resultado,
                          dem.TipoDemonstrativo,
                          dem.Id,
                          dem.IDReceita,
                          dem.IDDespesa
                        from CONDemonstrativoFinanceiro as dem
                        join CADDespesa as desp on desp.ID = dem.IDDespesa
                        where dem.TipoDemonstrativo = 1";

            var resultado = await contexto.DemonstrativoFinanceiro.FromSqlRaw(query).ToListAsync();
            return resultado;
        }
    }
}
