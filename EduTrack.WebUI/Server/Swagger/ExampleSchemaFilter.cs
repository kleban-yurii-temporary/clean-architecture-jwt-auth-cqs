using EduTrack.Contracts.Authentication;
using EduTrack.WebUI.Shared.Authentication;
using EduTrack.WebUI.Shared.Users;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EduTrack.WebUI.Server.Swagger
{
    public class ExampleSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if(context.Type == typeof(UserLoginDto))
            {
                schema.Example = new OpenApiObject()
                {
                    ["email"] = new OpenApiString("demo@email.com"),
                    ["password"] = new OpenApiPassword("demoPA$$W0RD")
                };
            }

            if (context.Type == typeof(UserRegisterDto))
            {
                schema.Example = new OpenApiObject()
                {
                    ["email"] = new OpenApiString("demo@email.com"),
                    ["password"] = new OpenApiPassword("demoPA$$W0RD"),
                    ["firstname"] = new OpenApiString("Yurii"),
                    ["lastname"] = new OpenApiPassword("Kleban")
                };
            }

            if (context.Type == typeof(UpdateUserRoleDto))
            {
                schema.Example = new OpenApiObject()
                {
                    ["id"] = new OpenApiString("---"),
                    ["role"] = new OpenApiPassword("teacher")
                };
            }

            if (context.Type == typeof(UpdateUserStatusDto))
            {
                schema.Example = new OpenApiObject()
                {
                    ["id"] = new OpenApiString("---"),
                    ["isapproved"] = new OpenApiBoolean(true)
                };
            }
        }
    }
}
