using ControleFinanceiro.Servicos.EntidadeServico;
using ControleFinanceiro.Servicos.Interfaces;
using ControleFinanceiro.Servicos.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.WebApp.Controllers
{
    public class DespesaController : Controller
    {
        protected readonly IServicoDespesa servicoDespesa;
        public DespesaController(IServicoDespesa servicoDespesa)
        {
            this.servicoDespesa = servicoDespesa;
        }
        // GET: DespesaController
        public async Task<IActionResult> ObterTodasDespesa()
        {
            try
            {
                var listaDespesa = await servicoDespesa.ObterTodos();
                return View(listaDespesa);
            }
            catch (Exception expection)
            {
                throw new Exception(expection.Message, expection);
            }    
        }

        // GET: DespesaController/Details/5
        public async Task<IActionResult> ObterDespesaPorId(Guid id)
        {
            try
            {
                var despesa = await servicoDespesa.ObterPorID(id);
                return View(despesa);
            }
            catch (Exception expection)
            {
                throw new Exception(expection.Message, expection);
            }     
        }

        // GET: DespesaController/Create
        public ActionResult AdicionarDespesa()
        {
            return PartialView("Views/Despesa/_AdicionarDespesa.cshtml");
        }

        // POST: DespesaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarDespesa(DespesaVO despesaVO)
        {
            try
            {
                if (despesaVO.Id == Guid.Empty)
                {
                    await servicoDespesa.AdicionarSalvar(despesaVO);
                }
                else
                {
                    await servicoDespesa.Atualizar(despesaVO);
                }
                return RedirectToAction(nameof(ObterTodasDespesa));
            }
            catch(Exception expection)
            {
                throw new Exception(expection.Message, expection);
            }
        }

        // GET: DespesaController/Delete/5
        public async Task<IActionResult> StatusDeletado(Guid id)
        {
            try
            {
                await servicoDespesa.StatusDeletado(id);
                return RedirectToAction(nameof(ObterTodasDespesa));
            }
            catch (Exception expection)
            {
                throw new Exception(expection.Message, expection);
            }
        }
    }
}
