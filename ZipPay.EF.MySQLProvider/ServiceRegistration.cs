using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ZipPay.EF.MySQLProvider
{
    public static class EFContextServicesRegistration
    {
        public static void AddDBContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ZipPayEFContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
        }
    }
}
