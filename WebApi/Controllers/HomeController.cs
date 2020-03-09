using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        IHttpContextAccessor _accessor;
        public HomeController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public IActionResult Index(int ?id)
        {
            var httpContext = _accessor.HttpContext;
            return View(httpContext);
        }
    }
}