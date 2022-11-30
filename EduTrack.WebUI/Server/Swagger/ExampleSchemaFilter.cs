using EduTrack.Contracts.Authentication;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EduTrack.WebUI.Server.Swagger
{
    public class ExampleSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if(context.Type == typeof(LoginRequest))
            {
                schema.Example = new OpenApiObject()
                {
                    ["email"] = new OpenApiString("demo@email.com"),
                    ["password"] = new OpenApiPassword("demoPA$$W0RD")
                };
            }

            if (context.Type == typeof(RegisterRequest))
            {
                schema.Example = new OpenApiObject()
                {
                    ["email"] = new OpenApiString("demo@email.com"),
                    ["password"] = new OpenApiPassword("demoPA$$W0RD"),
                    ["firstname"] = new OpenApiString("Yurii"),
                    ["lastname"] = new OpenApiPassword("Kleban"),
                };
            }
        }
    }
}
