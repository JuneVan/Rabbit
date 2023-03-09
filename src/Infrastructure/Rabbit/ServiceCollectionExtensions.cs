namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IIdentifier, NullIdentifier>();
            services.AddScoped<IThreadSignal, NullThreadSignal>();
            services.AddScoped<AsyncContinueMediator>();
            services.AddScoped<IEntityEventHelper, MediatREntityEventHelper>();
            services.AddScoped<IEventBus, MediatREventBus>();
            services.AddScoped<IAuthorizationChecker, AuthorizationChecker>();
            services.AddScoped<IPermissionProvider, NullPermissionProvider>();
            return services;
        }
    }
}
