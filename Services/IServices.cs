namespace API_MongoDB.Services
{
    public static class IServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<BenefitServices>();
            services.AddScoped<ContractTypeServices>();
            services.AddScoped<DepartmentServices>();
            services.AddScoped<PositionServices>();
            services.AddScoped<ShiftServices>();
            return services;
        }
    }
}
