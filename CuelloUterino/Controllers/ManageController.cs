using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CuelloUterino.Models;

namespace CuelloUterino.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
    }
}