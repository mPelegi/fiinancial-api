using Fiinancial.Api.Crosscutting.DTO.GeralCtx;
using Fiinancial.Api.Service.DependencyInjection;
using Fiinancial.Api.Service.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using System.Text;

namespace Fiinancial.Api.Interface
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddHttpClient();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<JwtSettings>();
            services.AddHealthChecks();

            services.AddCors(opt =>
                opt.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyMethod()));

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto | ForwardedHeaders.XForwardedHost;
            });

            //var intermediateProvider = services.BuildServiceProvider();
            //HttpContextAcessorHelper.Init(intermediateProvider);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Fiinancial",
                    Description = "Documentação da API",
                    Contact = new OpenApiContact() { Name = "Fiinancial Development Team", Email = "murilo.pelegi@hotmail.com", Url = new Uri("https://github.com/mPelegi") }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization Header.<br />
                        Preencha: 'Bearer' [espaço] seu token.<br />
                        Exemplo: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                      {
                            new OpenApiSecurityScheme
                            {
                                  Reference = new OpenApiReference
                                  {
                                        Type = ReferenceType.SecurityScheme, Id = "Bearer"
                                  }
                            },
                            new string[] { }
                      }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddControllers(options =>
            {
                //options.Filters.Add(new AuthorizeFilter("AuthPolicy"));
                options.EnableEndpointRouting = false;
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.Configure<JwtDto>(Configuration.GetSection("JwtSettings"));
            AddJwtAuthorization(services);

            ConfigureBindingsDependecyInjection.RegisterBindings(services, Configuration);
        }

        public void Configure(IApplicationBuilder app)
        {
            //app.UseMiddleware<ExceptionResponseInterceptor>();

            app.UseStaticFiles();
            //app.UseHttpsRedirection();
            app.UseForwardedHeaders();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseResponseCompression();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Faturas - API");
            });
        }

        private void AddJwtAuthorization(IServiceCollection services)
        {
            var jwtSettingsAuth = services.BuildServiceProvider().GetRequiredService<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(jwtSettingsAuth.SigningCredentials.Key.ToString());

            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer("FiinancialClient", jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettingsAuth.Issuer,
                        ValidAudience = jwtSettingsAuth.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });

            services.AddAuthorization(auth =>
            {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddAuthenticationSchemes("FiinancialClient")
                    .Build();
            }
            );
        }
    }
}
