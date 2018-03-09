using CuelloUterino.ModeloDatos;
using CuelloUterino.Models;
using CuelloUterino.Utiles;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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

            ApplicationDbContext db = new ApplicationDbContext();
            CreateRoles(db);
            CreateUsers(db);
            CreatePermision(db);
            db.Dispose();
            Constantes.Adecuadas= System.Configuration.ConfigurationManager.AppSettings["Adecuada"];
            Constantes.Positivo = System.Configuration.ConfigurationManager.AppSettings["Positivo"];
            Constantes.Negativo = System.Configuration.ConfigurationManager.AppSettings["Negativo"];
            Constantes.Indeterminado = System.Configuration.ConfigurationManager.AppSettings["Indeterminado"];
        }

        private void CreatePermision(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var user = userManager.FindByName("administrador@simed.com");
            if (!userManager.IsInRole(user.Id, "Administrador"))
            {
                userManager.AddToRole(user.Id, "Administrador");
            }
            if (!userManager.IsInRole(user.Id, "Consulta"))
            {
                userManager.AddToRole(user.Id, "Consulta");
            }

            user = userManager.FindByName("consulta@simed.com");
           
            if (!userManager.IsInRole(user.Id, "Consulta"))
            {
                userManager.AddToRole(user.Id, "Consulta");
            }

        }

        private void CreateUsers(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName("administrador@simed.com");
            if (user==null)
            {
                user = new ApplicationUser
                {
                    UserName = "administrador@simed.com",
                    Email = "administrador@simed.com",
                };
                userManager.Create(user, "Admin123**");
            }

            user = userManager.FindByName("consulta@simed.com");
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "consulta@simed.com",
                    Email = "consulta@simed.com",
                };
                userManager.Create(user, "Consulta123**");
            }
        }

        private void CreateRoles(ApplicationDbContext db)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!roleManager.RoleExists("Consulta"))
            {
                roleManager.Create(new IdentityRole("Consulta"));
            }

            if (!roleManager.RoleExists("Administrador"))
            {
                roleManager.Create(new IdentityRole("Administrador"));
            }
        }
    }
}
