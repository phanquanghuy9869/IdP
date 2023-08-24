using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ImageGallery.Client.Controllers
{
    [Authorize]
    public class HuyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
