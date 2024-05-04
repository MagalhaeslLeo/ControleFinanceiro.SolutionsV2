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
    public class ServicoModuloMenu : IServicoModuloMenu
    {
        protected readonly IMapper mapper;
        protected readonly IRepositorioModuloMenu repositorioModuloMenu;
        public ServicoModuloMenu(IMapper mapper, IRepositorioModuloMenu repositorioModuloMenu)
        {
            this.mapper = mapper;
            this.repositorioModuloMenu = repositorioModuloMenu;
                
        }
        public async Task AdicionarSalvar(ModuloMenuVO moduloMenuVO)
        {
            try
            {
                var moduloMenuEntidade = mapper.Map <ModuloMenu>(moduloMenuVO);
                await repositorioModuloMenu.AdicionarSalvar(moduloMenuEntidade);
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }
        }

        public async Task<ModuloMenuVO> Atualizar(ModuloMenuVO moduloMenuVO)
        {
            try
            {
                var converterModuloMenu = mapper.Map<ModuloMenu>(moduloMenuVO);
                var moduloMenu = await repositorioModuloMenu.Atualizar(converterModuloMenu);
                var converterModuloMenuVO = mapper.Map<ModuloMenuVO>(moduloMenu);
                return converterModuloMenuVO;
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }
        }

        public async Task<ModuloMenuVO> ObterPorID(Guid Id)
        {
            try
            {
                var moduloMenu = await repositorioModuloMenu.ObterPorID(Id);
                var moduloMenuVO = mapper.Map<ModuloMenuVO>(moduloMenu);
                return moduloMenuVO;
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }
        }

        public async Task<IEnumerable<ModuloMenuVO>> ObterTodos()
        {
            try
            {
                var moduloMenu = await repositorioModuloMenu.ObterTodos();
                var moduloMenuVO = mapper.Map<IEnumerable<ModuloMenuVO>>(moduloMenu);
                return moduloMenuVO;
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
                var moduloMenu = await repositorioModuloMenu.ObterPorID(Id);
                moduloMenu.IsDeleted = true;
                await repositorioModuloMenu.StatusDeletado(moduloMenu);
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }
        }
    }
}
