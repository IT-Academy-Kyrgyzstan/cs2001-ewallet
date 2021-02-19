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
using System.Security.Claims;
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

        [Authorize]
        public async Task<IActionResult> Index()
        {            
            var userBills = await _db.CardAccounts.Where(u => u.UserId == GetUserId()).ToArrayAsync();

            return View(userBills);
        }

        protected int GetUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = int.Parse(userId);

            return result;
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
