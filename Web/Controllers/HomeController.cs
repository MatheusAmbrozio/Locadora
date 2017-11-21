using LocadoraS2IT.Business.IBusiness;
using LocadoraS2IT.Shared.Entities;
using System.Web.Mvc;

namespace LocadoraS2IT.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}