namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IIdentifier, NullIdentifier>();
            services.AddScoped<IThreadSignal, NullThreadSignal>();
            services.AddScoped<IEntityChangeEventHelper, EntityChangeEventHelper>();
            services.AddScoped<IAuthorizationChecker, AuthorizationChecker>();
            services.AddScoped<IPermissionProvider, NullPermissionProvider>();
            return services;
        }
    }
}
