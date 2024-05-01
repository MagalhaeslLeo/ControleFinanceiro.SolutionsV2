using ControleFinanceiro.Dominio.IdBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Dominio.Entidades
{
    public class ModuloMenu : IDEntidade
    {
        public string NomeModuloMenu { get; set; }
        public bool StatusMenuAtivo { get; set; }
    }
}
