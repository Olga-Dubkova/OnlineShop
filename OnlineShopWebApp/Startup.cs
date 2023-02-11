using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.Db;
using OnlineShop.Db.Interfases;
using OnlineShopWebApp.Common;
using OnlineShopWebApp.Db;
using OnlineShopWebApp.Interfaces;
using Serilog;

namespace OnlineShopWebApp
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

		
			string connection = Configuration.GetConnectionString("MyShopDubkova");
			
			services.AddDbContext<DatabaseContext>(options =>
				 options.UseSqlServer(connection));

			services.AddSingleton<IUsersManager, InMemoryUsersManager>();
			services.AddSingleton<IRolesRepository, InMemoryRolesRepository>();
			services.AddTransient<IFavotiteRepository, FavotiteDbRepositoty>();
            services.AddTransient<IOrdersRepository, OrdersDbRepository>();
            services.AddTransient< ICartsRepository, CartsDbRepository >();
            services.AddTransient<IProductStore, ProductDbStore>();
            services.AddControllersWithViews();
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
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
				endpoints.MapControllerRoute(
					name: "MyArea",
					pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

				endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
