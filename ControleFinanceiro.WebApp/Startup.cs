using ControleFinanceiro.Dominio.Interfaces;
using ControleFinanceiro.Repositorio.ContextoDB;
using ControleFinanceiro.Repositorio.Repositorios;
using ControleFinanceiro.Servicos.Interfaces;
using ControleFinanceiro.Servicos.Servicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.UI;

namespace SouDizimista.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddControllersWithViews();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<Contexto>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("Base")));
            services.AddAutoMapper(typeof(Startup));

            // Repositorios
               services.AddRazorPages().AddMicrosoftIdentityUI();
               services.AddScoped(typeof(IRepositorioDespesa), typeof(RepositorioDespesa));
               services.AddScoped(typeof(IRepositorioReceita), typeof(RepositorioReceita));
               services.AddScoped(typeof(IRepositorioModuloMenu), typeof(RepositorioModuloMenu));


            //// Servicos
            services.AddScoped(typeof(IServicoDespesa), typeof(ServicoDespesa));
            services.AddScoped(typeof(IServicoReceita), typeof(ServicoReceita));
            services.AddScoped(typeof(IServicoModuloMenu), typeof(ServicoModuloMenu));
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Login}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Home",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Menu",
                    pattern: "{controller=Menu}/{action=GetMenuItems}/{id?}");
            });
        }
    }
}
