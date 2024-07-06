using ControleFinanceiro.Servicos.Interfaces;
using ControleFinanceiro.Servicos.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.WebApp.Controllers
{
    public class DemonstrativoFinanceiroController : Controller
    {
        protected readonly IServicoDemonstrativoFinanceiro servicoDemonstrativoFinanceiro;
        public DemonstrativoFinanceiroController(IServicoDemonstrativoFinanceiro servicoDemonstrativoFinanceiro)
        {
            this.servicoDemonstrativoFinanceiro = servicoDemonstrativoFinanceiro;
        }

        public async Task<IActionResult> ObterTodosRelatorioDespesa()
        {
            var demonstrativo = await servicoDemonstrativoFinanceiro.RelatorioGeralDespesa();
            return View(demonstrativo);
        }
    }
}
