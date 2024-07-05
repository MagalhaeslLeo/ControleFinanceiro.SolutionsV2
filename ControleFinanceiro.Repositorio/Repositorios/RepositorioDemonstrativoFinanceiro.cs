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

        public async Task<IEnumerable<Despesa>> RelatorioGeralDespesa()
        {
            //Variavel que receberá a consulta SQL
            var query = @"
                           -- Subconsulta para calcular a soma total das despesas
                           WITH TotalDespesas AS (
                               SELECT SUM(Resultado) AS total
                               FROM [ControleFinanceiro].[dbo].[CONDemonstrativoFinanceiro]
                               WHERE TipoDemonstrativo = 1
                           )
                            
                           -- Consulta principal para selecionar os campos desejados e fazer join com CADDesepsa
                           SELECT 
                               desp.descricao,
                               dem.[CreatedAt],
                               dem.[IsDeleted],
                               dem.[Resultado],
                               dem.[IDDespesa],
                               dem.[TipoDemonstrativo],
                               td.total
                           FROM 
                               [ControleFinanceiro].[dbo].[CONDemonstrativoFinanceiro] dem
                           JOIN 
                               CADDespesa desp ON dem.IDDespesa = desp.Id
                           CROSS JOIN 
                               TotalDespesas td
                           WHERE 
                               dem.TipoDemonstrativo = 1";
            var resultado = await contexto.Despesa.FromSqlRaw(query).ToListAsync();
            var retornoDespesaGeral = resultado.Select(r => new Despesa
            {
                Descricao = r.Descricao,
                CreatedAt = r.CreatedAt,
                IsDeleted = r.IsDeleted      
            }).ToList();
            return retornoDespesaGeral;
        }
    }
}
