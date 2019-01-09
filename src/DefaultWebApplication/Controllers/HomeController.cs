using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DefaultWebApplication.Models;
using Application.DefaultModule.Intefaces;

namespace DefaultWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITableDefaultService service;

        public HomeController(ITableDefaultService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            var result = service.GetAll(w => w.Id > 0);

            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
