using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EwalletContext _db;

        public HomeController(ILogger<HomeController> logger, EwalletContext db)
        {
            _logger = logger;
            _db = db;
        }


        public async Task<IActionResult> Index()
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == "tilek.kasymov"  /* User.Identity.Name */);
            var userBills = await _db.CardAccounts.Where(u => u.UserId == user.Id).ToArrayAsync();

            return View(userBills);
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
