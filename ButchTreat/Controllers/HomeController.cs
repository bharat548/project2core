using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ButchTreat.Models;
using ButchTreat.ViewModels;
using Microsoft.EntityFrameworkCore;
using ButchTreat.Data;

namespace ButchTreat.Controllers
{
    public class HomeController : Controller
    {
        //  private readonly IMailService _mailService;
        private readonly DutchContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_mailService = _mailService;
        }
        [HttpGet("contact")]
        public IActionResult Contact(ContactViewModel1 model)
        {
            if(ModelState.IsValid)
            ViewBag.Title = "Contact Us";
         //   _mailService.SendMessage("shawn@wildermuth.com", model.Subject);
         //ViewBag.UserMessage="Mail sent"
            return View();
        }
        public IActionResult Shop()
        {
            var results = from p in _context.Products
                          orderby p.Category
                          select p;
            return View(results.ToList());




        }
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }


