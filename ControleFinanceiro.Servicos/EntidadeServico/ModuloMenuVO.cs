using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servicos.EntidadeServico
{
    public class ModuloMenuVO
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public string NomeModuloMenu { get; set; }
        public bool StatusMenuAtivo { get; set; }
    }
}
