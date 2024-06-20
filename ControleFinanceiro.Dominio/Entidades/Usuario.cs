using ControleFinanceiro.Dominio.IdBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Dominio.Entidades
{
    public class Usuario : IDEntidade
    {
        public string NomeUsuario  {get; set;}
        public string EmailUsuario {get; set;}
        public string SenhaUsuario {get; set;}

    }
}
