using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        public AdminController(ILogger<HomeController> logger, EwalletContext db) : base(logger, db)
        { }

        public IActionResult ApplicationsView()
        {
            var applications = db.CardApplications.ToList();
            
            return View(applications);
        }
    }
}
