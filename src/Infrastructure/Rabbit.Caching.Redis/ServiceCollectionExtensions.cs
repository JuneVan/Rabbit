namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCaching(this IServiceCollection services, Action<RedisOptions> configure)
        {
            var options = new RedisOptions();
            configure?.Invoke(options);
            RedisHelper.Initialization(new CSRedisClient(options.ConnectionString));
            services.AddSingleton<IDistributedCache>(new RedisDistributedCache(RedisHelper.Instance));
            services.AddSingleton(typeof(IDistributedLocker), typeof(DistributedLocker));
            services.AddSingleton(implementationFactory => (new CSRedisClient(options.ConnectionString)));
            return services;
        }
    }
}
