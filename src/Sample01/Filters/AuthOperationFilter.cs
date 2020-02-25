// reference
// https://thecodebuzz.com/basic-authentication-using-operationfilter-in-swaggeropenapi-asp-net-core/

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Sample01.Filters
{
#pragma warning disable CS1591
    public class AuthOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var authorizeSchemes = new HashSet<string>(
                context.MethodInfo.GetCustomAttributes()
                    .OfType<AuthorizeAttribute>()
                    .Select(attr => attr.AuthenticationSchemes?.ToLower())
                    .Distinct()
                    .ToArray()
            );
            if (authorizeSchemes.Any() == false)
            {
                return;
            }

            if (authorizeSchemes.Contains("basic"))
            {
                var basicScheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "basic"
                    }
                };

                operation.Security.Add(new OpenApiSecurityRequirement
                {
                    [basicScheme] = new string[] { }
                });
            }

        }
    }
#pragma warning restore CS1591
}