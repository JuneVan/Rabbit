namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration, string routePrefix)
        {
            AddWebApi(services, configuration, routePrefix);
            AddSwaggerGen(services);
            AddCORS(services, configuration);
            AddValidation(services);
            AddMapper(services);
            AddHealthChecks(services);
            AddMediatR(services);
            AddServices(services, configuration);
            AddJWTAuthentication(services, configuration);
            return services;
        }
        private static void AddWebApi(IServiceCollection services, IConfiguration configuration, string routePrefix)
        {
            services.AddControllers(configure =>
            {
                if (!string.IsNullOrEmpty(routePrefix))
                {
                    configure.AddRoutePrefix(routePrefix);
                }
            });
            services.AddEndpointsApiExplorer();
        }

        // Swagger配置
        private static void AddSwaggerGen(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
             {
                 options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                 {
                     Description = "请求头授权示例：\"Authorization: Bearer {token}\"",
                     Name = "Authorization",
                     In = ParameterLocation.Header,
                     Type = SecuritySchemeType.Http,
                     Scheme = "bearer",
                     BearerFormat = "JWT"
                 });
                 options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    }
                                },
                                new string[] {}
                        }
                    });

                 options.SwaggerDoc("v1", new OpenApiInfo { Title = "Rabbit.Identity", Version = "v1", Description = "身份认证系统 WebAPI" });
                 options.CustomSchemaIds(type => type.FullName);
                 // 加载注释文档
                 foreach (var xmlFilePath in Directory.GetFiles(AppContext.BaseDirectory, "*.xml"))
                     options.IncludeXmlComments(xmlFilePath);
             });
        }

        private static void AddCORS(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
             {
                 options.AddPolicy(WebAPIDefaults.CorsName, policy =>
                 {
                     policy.AllowAnyOrigin()
                     .AllowAnyHeader()
                     .AllowAnyMethod();
                 });
             });
        }
        // 添加参数验证
        private static void AddValidation(IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(Program).Assembly);
        }
        // 添加对象映射
        private static void AddMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program).Assembly);
        }
        // 添加健康检查
        private static void AddHealthChecks(IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck("health", () => HealthCheckResult.Healthy());
        }
        // 添加MediatR 
        private static void AddMediatR(IServiceCollection services)
        {
            services.AddMediatR(typeof(Program).Assembly);
        }

        private static void AddJWTAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection("JWTAuthentication"));
            var jwtOptions = new JwtOptions();
            configuration.GetSection("JWTAuthentication").Bind(jwtOptions);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = jwtOptions.ValidateIssuer,
                     ValidateAudience = jwtOptions.ValidateAudience,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = jwtOptions.ValidIssuer,
                     ValidAudience = jwtOptions.ValidAudience,
                     IssuerSigningKey = JwtSecurityKey.Create(jwtOptions.SecretKey)
                 };

             });
        }
        private static void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCore();
            services.AddEntityFrameworkCore<IdentityDbContext>(configure =>
            {
                configure.UseNpgsql(configuration.GetConnectionString("PostgreSqlDb"));
            });
            services.AddScoped<IConnectionStringProvider, EfCoreConnectionStringProvider>();
            services.AddAspNetCore(configure =>
            {
                configure.RequestUrl = configuration["Settings:PermissionUrl"];
            });
            services.AddCaching(configure =>
            {
                configure.ConnectionString = configuration.GetConnectionString("RedisDb");
            });
           
            // IQuerier
            services.AddScoped<IUserQuerier, UserQuerier>();
            services.AddScoped<IRoleQuerier, RoleQuerier>();
            services.AddScoped<IPermissionQuerier, PermissionQuerier>();
            services.AddScoped<IAccountQuerier, AccountQuerier>();
        }
    }
}
