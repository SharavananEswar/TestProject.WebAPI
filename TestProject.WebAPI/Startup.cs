using FluentValidation;
using FluentValidation.AspNetCore;
using TestProject.WebAPI.Middlewares;
using TestProject.WebAPI.Validations;
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
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserRequestValidator>());

            services.AddDBContext(Configuration.GetConnectionString("DefaultConnection"));

            services.AddValidatorsFromAssemblyContaining<CreateUserRequestValidator>();

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

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

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
