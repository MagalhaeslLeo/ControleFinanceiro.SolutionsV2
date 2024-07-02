using ControleFinanceiro.Dominio.Entidades;
using ControleFinanceiro.Dominio.Interfaces;
using ControleFinanceiro.Repositorio.ContextoDB;
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
    }
}
