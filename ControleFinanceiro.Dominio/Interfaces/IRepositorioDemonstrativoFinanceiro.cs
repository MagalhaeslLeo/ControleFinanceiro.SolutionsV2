﻿using ControleFinanceiro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Dominio.Interfaces
{
    public interface IRepositorioDemonstrativoFinanceiro : IRepositorioBase<DemonstrativoFinanceiro>
    {
        Task <IEnumerable<DemonstrativoFinanceiro>> RelatorioGeralDespesa();
    }
}