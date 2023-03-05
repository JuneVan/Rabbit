namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAspNetCore(this IServiceCollection services, Action<PermissionOptions> configure)
        {
            services.AddHttpContextAccessor();
            services.AddHttpClient();
            services.AddScoped<IIdentifier, ClaimIdentifier>();
            services.Replace(new ServiceDescriptor(typeof(IThreadSignal), typeof(HttpThreadSignal), ServiceLifetime.Scoped));
            var options = new PermissionOptions();
            configure?.Invoke(options);
            services.Configure(configure);
            services.Replace(new ServiceDescriptor(typeof(IPermissionProvider), typeof(UrlPermissionProvider), ServiceLifetime.Scoped));
#pragma warning disable CS0618
            services.AddTransient<IValidatorFactory, FluentValidationValidatorFactory>();
#pragma warning restore CS0618 

            services.Configure<MvcOptions>(configure =>
            {
                // 需关闭自动验证
                configure.Filters.Add<FluentValidationValidationFilter>();
                configure.Filters.Add<ResultWrapperFilter>();
                configure.Filters.Add<PermissionFilter>();
                configure.Filters.Add<ExceptionFilter>();
            });
            return services;
        }
    }
}
