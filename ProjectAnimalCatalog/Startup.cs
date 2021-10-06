using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectAnimalCatalog.Data;
using ProjectAnimalCatalog.Repositories;

namespace ProjectAnimalCatalog
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ASPNETCOREPROJECTContext>(options => options.UseSqlServer("Data Source=DESKTOP-EKQUKID;Initial Catalog=ASPNETCOREPROJECT;Integrated Security=True"));
            services.AddScoped<IRepository, MyRepository>();
            services.AddScoped<ICommentRep, CommentRep>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ASPNETCOREPROJECTContext context)
        {

            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Deafault", "{Controller=Home}/{Action=HomePage}/{id?}");

            });
        }
    }
}
