using System.Reflection;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace SFC.Team.Api.Infrastructure.Extensions;

public static class SwaggerExtensions
{
    private const string SPECIFICATION_NAME = "common";
    private const string TITLE = "SFC.Team";
    private const string SECURITY_ID = "SFC.Team - Bearer";

    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(setupAction =>
        {
            setupAction.SwaggerDoc(SPECIFICATION_NAME, new()
            {
                Title = TITLE,
                Version = "1",
                Description = "Through this API you can create, update, get information about teams." +
                              "Create, cancel/accept/refuse, get information about team invites to players.",
                Contact = new()
                {
                    Email = "krivorukandrey@gmail.com",
                    Name = "Andrii Kryvoruk"
                }
            });

            setupAction.CustomSchemaIds(type => GetCustomSchemaId(type));

            // controller comments
            setupAction.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

            // security
            setupAction.AddSecurityDefinition(SECURITY_ID, new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Description = "Input a valid token to access this API."
            });

            setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = SECURITY_ID
                        }
                    },
                    new List<string>()
                }
            });
        });
    }

    public static void UseSwagger(this IApplicationBuilder builder)
    {
        SwaggerBuilderExtensions.UseSwagger(builder);
        builder.UseSwaggerUI(setupAction =>
        {
            setupAction.SwaggerEndpoint($"/swagger/{SPECIFICATION_NAME}/swagger.json", TITLE);
        });
    }

    #region Private

    private static string GetCustomSchemaId(Type type)
    {
        string id = type.Name;

        string? prefix = null;

        string? @namespace = type.Namespace;

        string teamsModelsPart = "SFC.Team.Api.Infrastructure.Models.Teams.";

        if (!string.IsNullOrEmpty(@namespace) && @namespace.Contains(teamsModelsPart, StringComparison.InvariantCulture))
        {
            prefix = @namespace.Substring(teamsModelsPart.Length)
                               .Split('.')
                               .FirstOrDefault();
        }

        return string.IsNullOrWhiteSpace(prefix) ? id : $"{prefix}.{id}";
    }

    #endregion Private
}