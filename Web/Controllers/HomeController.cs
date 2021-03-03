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

        public async Task<IActionResult> Index()
        {
            var userBills = await db.CardAccounts.Where(u => u.UserId == UserId).ToArrayAsync();
            
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
        
        public IActionResult FormApp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FormApp(FormAppViewModels model)
        {
            if (ModelState.IsValid) 
            {
                var userLogin = User.Identity.Name;
                var user = await db.Users.FirstOrDefaultAsync(x => x.UserName == userLogin);
                var nameCard = $"{user.FirstName} + {user.LastName} + {model.CardView}";

                db.CardApplications.Add(new DataAccess.CardApplication
                {
                    UserId = user.Id,
                    CurruncyEnum = model.CurruncyEnum,
                    CardView = model.CardView,
                    Status = 2,
                    CreatedDate = DateTime.Now

                });
                await db.SaveChangesAsync();
            }
                return View(model);        
        }

    }
}
