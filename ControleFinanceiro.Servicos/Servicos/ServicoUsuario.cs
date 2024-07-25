using AutoMapper;
using ControleFinanceiro.Dominio.Entidades;
using ControleFinanceiro.Dominio.Interfaces;
using ControleFinanceiro.Servicos.EntidadeServico;
using ControleFinanceiro.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servicos.Servicos
{
    public class ServicoUsuario : IServicoUsuario
    {
        protected readonly IMapper mapper;
        protected readonly IRepositorioUsuario repositorioUsuario;

        public ServicoUsuario(IMapper mapper, IRepositorioUsuario repositorioUsuario)
        {
            this.mapper = mapper;
            this.repositorioUsuario = repositorioUsuario;
        }

        public async Task AdicionarSalvar(UsuarioVO usuarioVO)
        {
            try
            {
                var usuario = mapper.Map<Usuario>(usuarioVO);
                await repositorioUsuario.AdicionarSalvar(usuario);
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }

        }

        public async Task<UsuarioVO> Atualizar(UsuarioVO usuarioVO)
        {
            try
            {
               var converterUsuario = mapper.Map<Usuario>(usuarioVO);
               var usuario = await repositorioUsuario.Atualizar(converterUsuario); 
               var atualizaUsuarioVO = mapper.Map<UsuarioVO>(usuario);
               return atualizaUsuarioVO;
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }

        }

        public async Task<UsuarioVO> ObterPorID(Guid Id)
        {
            try
            {
                var usuarioVO = await repositorioUsuario.ObterPorID(Id);
                var converterUsuarioVO = mapper.Map<UsuarioVO>(usuarioVO);
                return converterUsuarioVO;
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }
        }

        public async Task<IEnumerable<UsuarioVO>> ObterTodos()
        {
            try
            {
                var listaUsuarioVO = await repositorioUsuario.ObterTodos();
                var converterListaUsuario = mapper.Map<IEnumerable<UsuarioVO>>(listaUsuarioVO);
                return converterListaUsuario;
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }
        }
        public async Task<UsuarioVO> ObterUsuarioPorEmailSenha(string email, string senha)
        {
            try
            {
                var usuarioVO = await repositorioUsuario.ObterUsuarioPorEmailSenha(email, senha);
                if (usuarioVO == null)
                {
                    throw (new Exception("Usuario inexistente"));
                }
                var converterUsuarioVO = mapper.Map<UsuarioVO>(usuarioVO);
                return converterUsuarioVO;
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }
        }

        public async Task StatusDeletado(Guid Id)
        {
            try
            {
                var usuario = await repositorioUsuario.ObterPorID(Id);
                usuario.IsDeleted = true;
                await repositorioUsuario.StatusDeletado(usuario);
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }
        }
    }
}
