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
    public class ModuloMenuMap : IEntityTypeConfiguration<ModuloMenu>
    {
        public void Configure(EntityTypeBuilder<ModuloMenu> builder)
        {
            builder.ToTable("ModuloMenu");
            builder.HasQueryFilter(m => !m.IsDeleted);
        }
    }


}
