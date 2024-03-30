namespace API_MongoDB.Services
{
    public static class IServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<BenefitServices>();
            return services;
        }
    }
}
