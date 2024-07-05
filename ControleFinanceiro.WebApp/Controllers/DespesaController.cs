using ControleFinanceiro.Servicos.EntidadeServico;
using ControleFinanceiro.Servicos.Interfaces;
using ControleFinanceiro.Servicos.Servicos;
using ControleFinanceiro.Servicos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

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

        public async Task<IActionResult> ObterTodosRelatorioDespesa()
        {
            var teste = await servicoDespesa.RelatorioGeralDespesa();
            return View(teste);
        }
        public async Task<IActionResult> ObterTodasDespesa(int? page)
        {
            int pageSize = 5; //Define tamanho da página pelo número de despesas
            int pageNumber = (page ?? 1); //Se page for nulo, pageNumber será sempre 1
            
            try
            {
                var listaDespesa = await servicoDespesa.ObterTodos();
                var despesasPaginadas = listaDespesa.ToPagedList(pageNumber, pageSize);

                var despesasPaginadasViewModel = new PaginacaoViewModel
                {
                    Despesas = despesasPaginadas,
                    TotalDespesa = listaDespesa.Sum(d=>d.Valor)
                };
                return View(despesasPaginadasViewModel);
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
                return PartialView("_ConsultarDespesa", despesa);
            }
            catch (Exception expection)
            {
                throw new Exception(expection.Message, expection);
            }     
        }

        // GET: DespesaController/Create
        public ActionResult AdicionarDespesa()
        {
            return PartialView("_AdicionarDespesa");
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
