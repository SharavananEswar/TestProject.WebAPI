using Microsoft.AspNetCore.Mvc;
using ZipPay.EF.MySQLProvider;
using ZipPay.Repository;
using ZipPay.Repository.Contracts;
using ZipPay.Service;
using ZipPay.Service.Contracts;

namespace TestProject.WebAPI
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
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllers();

            services.AddDBContext(Configuration.GetConnectionString("DefaultConnection"));

            services.AddTransient<IUserAccountsRepository, UserAccountsRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IUserAccountsService, UserAccountsService>();
            services.AddTransient<IUsersService, UsersService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
