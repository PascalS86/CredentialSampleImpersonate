using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CredentialSample.Caller.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.Message = HttpContext.User.Identity.Name.ToString();
            System.Security.Principal.WindowsImpersonationContext impersonationContext;
            impersonationContext =
                ((System.Security.Principal.WindowsIdentity)User.Identity).Impersonate();

            using (HttpClient client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
            {
                var result = await client.GetAsync("http://localhost:52720/api/values");


            }
            impersonationContext.Undo();

            return View();
        }
    }
}
