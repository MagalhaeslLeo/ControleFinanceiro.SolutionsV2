using ControleFinanceiro.Dominio.IdBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Dominio.Entidades
{
    public class Receita : IDEntidade
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
