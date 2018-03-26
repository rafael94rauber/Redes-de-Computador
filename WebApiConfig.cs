using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GA.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            
            //ROTA PARA ENVIAR/RECEBER MENSAGEM
            config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{action}/{UsuarioEnvio}/{UsuarioReceber}/{conteudoMensagem}",
                    defaults: new {
                        UsuarioEnvio = RouteParameter.Optional,
                        UsuarioReceber = RouteParameter.Optional,
                        conteudoMensagem = RouteParameter.Optional
                    }
             );
        }
    }
}
