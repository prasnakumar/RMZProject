using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Interfaces.Helper
{
    public class TypeParameterFilter : IParameterFilter
    {
        readonly IServiceScopeFactory _serviceScopeFactory;

        public TypeParameterFilter(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {
            if (parameter.Name.Equals("type", StringComparison.InvariantCultureIgnoreCase))
            {

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    string[] types = { "Building", "Facility", "Zones" };

                    parameter.Schema.Enum = types.Select(p => new OpenApiString(p)).ToList<IOpenApiAny>();

                }
            }
        }
    }
}
    