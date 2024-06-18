using ControleFinanceiro.Servicos.EntidadeServico;
using ControleFinanceiro.Servicos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ControleFinanceiro.WebApp.Controllers
{
    public class ModuloMenuController : Controller
    {
        protected readonly IServicoModuloMenu servicoModuloMenu;
        public ModuloMenuController(IServicoModuloMenu servicoModuloMenu)
        {
            this.servicoModuloMenu = servicoModuloMenu;
        }

        [HttpGet]
        public IActionResult FuncionalidadeMenu()
        {
            var menuState = HttpContext.Session.GetString("MenuState");
            return Json(menuState);
        }

        [HttpPost]
        public IActionResult DefinirEstadoFuncionalidadeMenu([FromBody] Dictionary<string, string> menuState)
        {
            var menuStateJson = JsonSerializer.Serialize(menuState);
            HttpContext.Session.SetString("MenuState", menuStateJson);
            return Ok();
        }

        // GET: ModuloMenuController
        public async Task<IActionResult> ObterTodosModuloMenu()
        {
            try
            {
                var listaModulo = await servicoModuloMenu.ObterTodos();
                return View(listaModulo);
            }
            catch (Exception expection)
            {
                throw new Exception(expection.Message, expection);
            }
        }

        // GET: ModuloMenuController/Details/5
        public async Task <IActionResult> ObterModuloMenuPorId(Guid id)
        {
            try
            {
                var modulo = await servicoModuloMenu.ObterPorID(id);
                return View(modulo);
            }
            catch (Exception expection)
            {
                throw new Exception(expection.Message, expection);
            }
        }

        // GET: ModuloMenuController/Create
        public ActionResult AdicionarModuloMenu()
        {
            return View();
        }

        // POST: ModuloMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> AdicionarModuloMenu(ModuloMenuVO moduloMenuVO)
        {
            try
            {
                if (moduloMenuVO.Id == Guid.Empty)
                {
                    await servicoModuloMenu.AdicionarSalvar(moduloMenuVO);
                }
                else
                {
                    await servicoModuloMenu.Atualizar(moduloMenuVO);
                }
                return RedirectToAction(nameof(ObterTodosModuloMenu));
            }
            catch (Exception expection)
            {
                throw new Exception(expection.Message, expection);
            }
        }

        // GET: ModuloMenuController/Delete/5
        public async Task<IActionResult> StatusDeletado(Guid id)
        {
            try
            {
                await servicoModuloMenu.StatusDeletado(id);
                return RedirectToAction(nameof(ObterTodosModuloMenu));
            }
            catch (Exception expection)
            {
                throw new Exception(expection.Message, expection);
            }
        }
    }
}
