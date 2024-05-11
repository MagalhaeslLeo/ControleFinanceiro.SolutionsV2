using ControleFinanceiro.Servicos.EntidadeServico;
using ControleFinanceiro.Servicos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.WebApp.Controllers
{
    public class ReceitaController : Controller
    {
        protected readonly IServicoReceita servicoReceita;
        public ReceitaController(IServicoReceita servicoReceita)
        {
            this.servicoReceita = servicoReceita;
        }

        // GET: ReceitaController
        public async Task <IActionResult> ObterTodasReceita()
        {
            try
            {
                var listaReceita = await servicoReceita.ObterTodos();
                return View(listaReceita);
            }
            catch (Exception expection)
            {
                throw new Exception(expection.Message, expection);
            }

        }

        // GET: ReceitaController/Details/5
        public async Task<IActionResult> ObterReceitaPorId(Guid id)
        {

            try
            {
                var receita = await servicoReceita.ObterPorID(id);
                return PartialView("_ConsultarReceita", receita);
            }
            catch (Exception expection)
            {
                throw new Exception(expection.Message, expection);
            }
        }

        // GET: ReceitaController/Create
        public ActionResult AdicionarReceita()
        {
            return PartialView("_AdicionarReceita");
        }

        // POST: ReceitaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> AdicionarReceita(ReceitaVO receitaVO)
        {
            try
            {
                if (receitaVO.Id == Guid.Empty)
                {
                    await servicoReceita.AdicionarSalvar(receitaVO);
                }
                else
                {
                    await servicoReceita.Atualizar(receitaVO);
                }
                return RedirectToAction(nameof(ObterTodasReceita));
            }
            catch (Exception expection)
            {
                throw new Exception(expection.Message, expection);
            }
        }

        // GET: ReceitaController/Delete/5
        public async Task<IActionResult> StatusDeletado(Guid id)
        {
            try
            {
                await servicoReceita.StatusDeletado(id);
                return RedirectToAction(nameof(ObterTodasReceita));
            }
            catch (Exception expection)
            {
                throw new Exception(expection.Message, expection);
            }

        }
    }
}
