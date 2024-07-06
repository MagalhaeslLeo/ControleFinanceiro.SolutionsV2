using AutoMapper;
using ControleFinanceiro.Dominio.Interfaces;
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
    public class ServicoDemonstrativoFinanceiro : IServicoDemonstrativoFinanceiro
    {
        protected readonly IRepositorioDemonstrativoFinanceiro repositorioDemonstrativoFinanceiro;
        protected readonly IMapper mapper;
        public ServicoDemonstrativoFinanceiro(IRepositorioDemonstrativoFinanceiro repositorioDemonstrativoFinanceiro, IMapper mapper)
        {
            this.repositorioDemonstrativoFinanceiro = repositorioDemonstrativoFinanceiro;
            this.mapper = mapper;
        }
        public Task AdicionarSalvar(DemonstrativoFinanceiroVO demonstrativoFinanceiroVO)
        {
            throw new NotImplementedException();
        }

        public Task<DemonstrativoFinanceiroVO> Atualizar(DemonstrativoFinanceiroVO demonstrativoFinanceiroVO)
        {
            throw new NotImplementedException();
        }

        public Task<DemonstrativoFinanceiroVO> ObterPorID(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DemonstrativoFinanceiroVO>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task StatusDeletado(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DemonstrativoFinanceiroVO>> RelatorioGeralDespesa()
        {
            try
            {
                var demonstrativoFinanceiros = await repositorioDemonstrativoFinanceiro.RelatorioGeralDespesa();
                var listaDemonstrativosVO = mapper.Map<IEnumerable<DemonstrativoFinanceiroVO>>(demonstrativoFinanceiros);

                var resultadoGeral = listaDemonstrativosVO.Sum(d => d.Resultado);
                foreach (var demonstrativo in listaDemonstrativosVO)
                {
                    demonstrativo.SomatorioGeral = resultadoGeral;
                }

                return listaDemonstrativosVO;
            }
            catch (Exception expection)
            {

                throw new Exception(expection.Message, expection);
            }
        }
    }
}
