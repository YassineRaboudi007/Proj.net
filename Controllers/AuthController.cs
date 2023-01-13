using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_note.Controllers
{
    [Route("Auth")]
    public class AuthController : Controller
    {
        // GET: AuthController
        [Route("login")]
        public ActionResult Login()
        {
            return View();
        }

        [Route("signup")]
        public ActionResult SignUp()
        {
            return View();
        }
    }
}
