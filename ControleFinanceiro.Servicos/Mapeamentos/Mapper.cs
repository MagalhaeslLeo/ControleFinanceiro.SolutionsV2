using AutoMapper;
using ControleFinanceiro.Dominio.Entidades;
using ControleFinanceiro.Servicos.EntidadeServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servicos.Mapeamentos
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<DespesaVO, Despesa>().ReverseMap();
            CreateMap<ReceitaVO, Receita>().ReverseMap();
            CreateMap<ModuloMenuVO, ModuloMenu>().ReverseMap();
            CreateMap<UsuarioVO, Usuario>().ReverseMap();
        }
    }
}
