using ControleFinanceiro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ControleFinanceiro.Repositorio.ContextoDB
{
    public class Contexto : DbContext
    { 
        public DbSet<Receita> Receita { get; set; }
        public DbSet<Despesa> Despesa { get; set; }
        public DbSet<ModuloMenu> ModuloMenu { get; set; }
        public Contexto(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

}
    

    

