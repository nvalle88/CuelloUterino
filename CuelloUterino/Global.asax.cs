using CuelloUterino.Utiles;
using SmartAdminMvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CuelloUterino
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Constantes.Adecuadas= System.Configuration.ConfigurationManager.AppSettings["Adecuada"];
            Constantes.Positivo = System.Configuration.ConfigurationManager.AppSettings["Positivo"];
            Constantes.Negativo = System.Configuration.ConfigurationManager.AppSettings["Negativo"];
            Constantes.Indeterminado = System.Configuration.ConfigurationManager.AppSettings["Indeterminado"];
        }
    }
}
