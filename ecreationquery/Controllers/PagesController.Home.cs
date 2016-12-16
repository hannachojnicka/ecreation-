using System.Web.Mvc;

namespace ecreationquery.Controllers
{
    public partial class PagesController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }
    }
}