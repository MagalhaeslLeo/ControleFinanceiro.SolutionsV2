using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servicos.EntidadeServico
{
    public class DemonstrativoFinanceiroVO
    {
        public Guid ID { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Resultado { get; set; }

        public decimal SomatorioGeral { get; set; }


        public ReceitaVO Receita { get; set; }
        public DespesaVO Despesa { get; set; }


        public IEnumerable<DespesaVO> Despesas { get; set; }
        public IEnumerable<ReceitaVO> Receitas { get; set; }
    }
}
