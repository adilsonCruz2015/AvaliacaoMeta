using System.Web.Http;
using Swashbuckle.Application;
using System.Reflection;
using System;

namespace AvaliacaoMeta.BackEnd.Api
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            string versao = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion($"v1", $"Documentação API Gestão de Contatos {versao}");

                    c.IncludeXmlComments(string.Format(
                    @"{0}\bin\AvaliacaoMeta.BackEnd.Api.xml",
                    AppDomain.CurrentDomain.BaseDirectory));

                    c.DescribeAllEnumsAsStrings();
                })
                .EnableSwaggerUi(c =>
                {
                    c.DocumentTitle($"Documentação API Gestão de Contatos {versao}");

                    c.SupportedSubmitMethods(new string[] { });
                });
        }
    }
}
