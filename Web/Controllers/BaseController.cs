using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ILogger<HomeController> _logger;
        protected readonly EwalletContext db;
        public BaseController(ILogger<HomeController> logger, EwalletContext db)
        {
            _logger = logger;
            this.db = db;
        }
        protected int GetUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = int.Parse(userId);

            return result;
        }
    }
}
