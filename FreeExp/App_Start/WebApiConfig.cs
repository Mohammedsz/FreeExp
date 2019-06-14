using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace FreeExp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;

            config.Formatters.Insert(0,
                new JsonPropertyCaseFormatter(config.Formatters.JsonFormatter.SerializerSettings));
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

    public class JsonPropertyCaseFormatter : JsonMediaTypeFormatter
    {
        private readonly JsonSerializerSettings globalSerializerSettings;

        public JsonPropertyCaseFormatter(JsonSerializerSettings globalSerializerSettings)
        {
            this.globalSerializerSettings = globalSerializerSettings;
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/javascript"));
        }

        public override MediaTypeFormatter GetPerRequestFormatterInstance(
            Type type,
            HttpRequestMessage request,
            MediaTypeHeaderValue mediaType)
        {
            var formatter = new JsonMediaTypeFormatter
            {
                SerializerSettings = globalSerializerSettings
            };

            IEnumerable<string> values;

            var result = request.Headers.TryGetValues("X-JsonResponseCase", out values)
                ? values.First()
                : "Pascal";

            formatter.SerializerSettings.ContractResolver =
                result.Equals("Camel", StringComparison.InvariantCultureIgnoreCase)
                    ? new CamelCasePropertyNamesContractResolver()
                    : new DefaultContractResolver();

            return formatter;
        }
    }
}
