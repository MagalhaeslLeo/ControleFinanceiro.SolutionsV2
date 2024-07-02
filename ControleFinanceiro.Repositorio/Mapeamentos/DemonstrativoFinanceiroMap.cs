using ControleFinanceiro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Repositorio.Mapeamentos
{
    public class DemonstrativoFinanceiroMap : IEntityTypeConfiguration<DemonstrativoFinanceiro>
    {
        public void Configure(EntityTypeBuilder<DemonstrativoFinanceiro> builder)
        {
            builder.ToTable("CONDemonstrativoFinanceiro");
            builder.HasQueryFilter(d => !d.IsDeleted);
        }
    }

}
