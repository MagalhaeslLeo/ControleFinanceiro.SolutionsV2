using ControleFinanceiro.Servicos.EntidadeServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ControleFinanceiro.Servicos.ViewModel
{
    public class PaginacaoViewModel
    {
        public IPagedList<DespesaVO> Despesas { get; set; }
        public IPagedList<ReceitaVO> Receitas { get; set; }
        public IPagedList<UsuarioVO> Usuarios { get; set; }
        public decimal TotalDespesa { get; set; }
        public decimal TotalReceita { get; set;}
    }
}
