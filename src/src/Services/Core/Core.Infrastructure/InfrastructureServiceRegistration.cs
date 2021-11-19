using Core.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<CoreContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("CoreContext")));

            //services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            //services.AddScoped<IOrderRepository, OrderRepository>();

            //services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));

            //services.AddFluentEmail(string.Empty)
            //    .AddSmtpSender(configuration["EmailSettings:SMTP:Host"],
            //        int.Parse(configuration["EmailSettings:SMTP:Port"]));
            //services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}