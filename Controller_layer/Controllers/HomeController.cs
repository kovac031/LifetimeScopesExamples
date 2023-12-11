using System.Diagnostics;
using Controller_layer.Models;
using Controller_layer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Controller_layer.Controllers
{
    public class HomeController : Controller
    {
        private ISingletonService _singleton;
        private IScopedService _scoped;
        private ITransientService _transient;

        public HomeController(
            ISingletonService singleton,
            IScopedService scoped,
            ITransientService transient)
        {
            _singleton = singleton;
            _scoped = scoped;
            _transient = transient;
        }

        public IActionResult Index() 
        {
            return View("Index");
        }

        public IActionResult Singleton()
        {
            return View("Singleton", _singleton.GetGuid());
        }

        public IActionResult Scoped()
        {
            return View("Scoped", _scoped.GetGuid());
        }

        public IActionResult Transient()
        {
            return View("Transient", _transient.GetGuid());
        }
    }
}