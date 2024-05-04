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
    public class ServicoReceita : IServicoReceita
    {
        protected readonly IMapper mapper;
        protected readonly IRepositorioReceita repositorioReceita;
        public ServicoReceita(IMapper mapper, IRepositorioReceita repositorioReceita)
        {
                this.mapper = mapper;
                this.repositorioReceita= repositorioReceita;
        }
        public async Task AdicionarSalvar(ReceitaVO receitaVO)
        {
            try
            {
                var receitaEntidade = mapper.Map<Receita>(receitaVO);
                await repositorioReceita.AdicionarSalvar(receitaEntidade);
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }
        }

        public async Task<ReceitaVO> Atualizar(ReceitaVO receitaVO)
        {
            try
            {
                var converterReceita = mapper.Map<Receita>(receitaVO);
                await repositorioReceita.Atualizar(converterReceita);
                var converterReceitaVO = mapper.Map<ReceitaVO>(converterReceita);
                return converterReceitaVO;
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }
        }

        public async Task<ReceitaVO> ObterPorID(Guid Id)
        {
            try
            {
                var receita = await repositorioReceita.ObterPorID(Id);
                var receitaVO = mapper.Map<ReceitaVO>(Id);
                return receitaVO;
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }
        }

        public async Task<IEnumerable<ReceitaVO>> ObterTodos()
        {
            try
            {
                var receita = await repositorioReceita.ObterTodos();
                var receitaVO = mapper.Map<IEnumerable<ReceitaVO>>(receita);
                return receitaVO;
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
                var receita = await repositorioReceita.ObterPorID(Id);
                receita.IsDeleted = true;
                await repositorioReceita.StatusDeletado(receita);
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }
        }
    }
}
