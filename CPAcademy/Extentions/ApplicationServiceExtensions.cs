namespace CPAcademy.Extentions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.Configure<MailSettings>(config.GetSection("MailSettings"));
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IMailService, MailService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



            return services;
        }

    }
}