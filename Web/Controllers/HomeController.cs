using DataAccess;
using DataAccess.Enum;
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
                var user = await db.Users.FirstOrDefaultAsync(x => x.Id == UserId);
                var nameCard = $"{user.FirstName} + {user.LastName} + {model.CardView}";

                db.CardApplications.Add(new DataAccess.CardApplication
                {
                    UserId = this.UserId,
                    Сurruncy = model.Curruncy,
                    CardView = model.CardView,
                    Status = StatusesEnum.Considering,
                    CreatedDate = DateTime.Now

                });
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
                return View(model);        
        }

    }
}
