using ControleFinanceiro.Servicos.EntidadeServico;
using ControleFinanceiro.Servicos.Interfaces;
using ControleFinanceiro.Servicos.Servicos;
using ControleFinanceiro.Servicos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using X.PagedList;

namespace ControleFinanceiro.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        protected readonly IServicoUsuario servicoUsuario;
        public UsuarioController(IServicoUsuario servicoUsuario)
        {
            this.servicoUsuario = servicoUsuario;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosUsuarios(int? page)
        {
            int pageSize = 5; //Define tamanho da página pelo número de despesas
            int pageNumber = (page ?? 1); //Se page for nulo, pageNumber será sempre 1

            try
            {
                var listaUsuario = await servicoUsuario.ObterTodos();
                var usuariosPaginados = listaUsuario.ToPagedList(pageNumber, pageSize);

                var usuariosPaginadasViewModel = new PaginacaoViewModel
                {
                    Usuarios = usuariosPaginados
                };

                return View(usuariosPaginadasViewModel);
            }
            catch (Exception expection)
            {
                throw new Exception(expection.Message, expection);
            }

        }

        [HttpGet]
        public async Task<IActionResult> ObterUsuarioPorId(Guid id)
        {
            try
            {
                var usuario = await servicoUsuario.ObterPorID(id);
                return PartialView(usuario);
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }
        }

        [HttpGet]

        public ActionResult AdicionarUsuario()
        {
            return PartialView("");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarUsuario(UsuarioVO usuarioVO)
        {
            try
            {
                if (usuarioVO.Id == Guid.Empty)
                {
                    await servicoUsuario.AdicionarSalvar(usuarioVO);
                }
                else
                {
                    await servicoUsuario.Atualizar(usuarioVO);
                }
                return RedirectToAction(nameof(ObterTodosUsuarios));
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }
        }
        public async Task<IActionResult> StatusDeletado(Guid Id)
        {
            try
            {
                await servicoUsuario.StatusDeletado(Id);
                return RedirectToAction(nameof(ObterTodosUsuarios));
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }

        }


    }
}
