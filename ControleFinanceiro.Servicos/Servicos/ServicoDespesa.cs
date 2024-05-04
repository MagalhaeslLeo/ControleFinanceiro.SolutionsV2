using AutoMapper;
using ControleFinanceiro.Dominio.Entidades;
using ControleFinanceiro.Dominio.Interfaces;
using ControleFinanceiro.Repositorio.ContextoDB;
using ControleFinanceiro.Repositorio.Repositórios;
using ControleFinanceiro.Servicos.EntidadeServico;
using ControleFinanceiro.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servicos.Servicos
{
    public class ServicoDespesa : IServicoDespesa
    {
        protected readonly IMapper mapper;
        protected readonly IRepositorioDespesa repositorioDespesa;
        public ServicoDespesa(IMapper mapper, IRepositorioDespesa repositorioDespesa)
        {
                this.mapper = mapper;
                this.repositorioDespesa = repositorioDespesa;
        }
        public async Task AdicionarSalvar(DespesaVO despesaVO)
        {
            try
            {
                var despesaEntidade = mapper.Map<Despesa>(despesaVO);
                await repositorioDespesa.AdicionarSalvar(despesaEntidade);
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }
            
        }

        public async Task<DespesaVO> Atualizar(DespesaVO despesaVO)
        {
            try
            {
                var converterDespesa = mapper.Map<Despesa>(despesaVO);
                var despesa = await repositorioDespesa.Atualizar(converterDespesa);
                var converterDespesaVO = mapper.Map<DespesaVO>(despesa);
                return converterDespesaVO;

            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }
        }

        public async Task<DespesaVO> ObterPorID(Guid Id)
        {
            try
            {
                var despesa = await repositorioDespesa.ObterPorID(Id);
                var despesaVO = mapper.Map<DespesaVO>(despesa);
                return despesaVO;
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }
        }

        public async Task<IEnumerable<DespesaVO>> ObterTodos()
        {
            try
            {
                var despesa = await repositorioDespesa.ObterTodos();
                var despesaVO = mapper.Map<IEnumerable<DespesaVO>>(despesa);
                return despesaVO;
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
                var despesa = await repositorioDespesa.ObterPorID(Id);
                despesa.IsDeleted = true;
                await repositorioDespesa.StatusDeletado(despesa);
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }
        }
    }
}
