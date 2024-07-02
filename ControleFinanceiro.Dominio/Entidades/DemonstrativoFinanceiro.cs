using ControleFinanceiro.Dominio.Enum.DemonstrativoFinanceiro;
using ControleFinanceiro.Dominio.IdBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Dominio.Entidades
{

    public class DemonstrativoFinanceiro : IDEntidade
    {
        public decimal Resultado { get; set; }
        public Guid? IDDespesa { get; set; }
        public Guid? IDReceita { get; set; }

        public TipoDemonstrativo TipoDemonstrativo { get; set; }
    }
}
