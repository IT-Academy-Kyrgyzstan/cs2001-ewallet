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

    public class HomeController : BaseController
    {
        public HomeController(ILogger<HomeController> logger, EwalletContext db) : base(logger,db)
        { }


        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userBills = await db.CardAccounts.Where(u => u.UserId == GetUserId()).ToArrayAsync();
            
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
