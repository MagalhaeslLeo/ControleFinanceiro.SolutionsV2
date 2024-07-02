using AutoMapper;
using ControleFinanceiro.Dominio.Entidades;
using ControleFinanceiro.Dominio.Enum.DemonstrativoFinanceiro;
using ControleFinanceiro.Dominio.Interfaces;
using ControleFinanceiro.Repositorio.ContextoDB;
using ControleFinanceiro.Repositorio.Repositorios;
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
        protected readonly IRepositorioDemonstrativoFinanceiro repositorioDemonstrativoFinanceiro;
        public ServicoDespesa(IMapper mapper, IRepositorioDespesa repositorioDespesa,
            IRepositorioDemonstrativoFinanceiro repositorioDemonstrativoFinanceiro)
        {
                this.mapper = mapper;
                this.repositorioDespesa = repositorioDespesa;
                this.repositorioDemonstrativoFinanceiro = repositorioDemonstrativoFinanceiro;
        }
        public async Task AdicionarSalvar(DespesaVO despesaVO)
        {
            try
            {
                var despesaEntidade = mapper.Map<Despesa>(despesaVO);
                if(despesaEntidade.Id == Guid.Empty)
                {
                    despesaEntidade.Id= Guid.NewGuid();
                }
                await repositorioDespesa.AdicionarSalvar(despesaEntidade);
                DemonstrativoFinanceiro demonstrativoFinanceiro = new DemonstrativoFinanceiro
                {
                    IDDespesa = despesaEntidade.Id,
                    CreatedAt = despesaEntidade.CreatedAt,
                    Resultado = despesaVO.Valor,
                    TipoDemonstrativo = TipoDemonstrativo.Despesa
                };
                await repositorioDemonstrativoFinanceiro.AdicionarSalvar(demonstrativoFinanceiro);

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
