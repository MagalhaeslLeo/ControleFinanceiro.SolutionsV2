using ControleFinanceiro.Servicos.EntidadeServico;
using ControleFinanceiro.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public async Task<IActionResult> ObterTodosUsuarios()
        {
            try
            {
                var listaUsuarios = await servicoUsuario.ObterTodos();
                return View(listaUsuarios);
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
                return View(usuario);
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
