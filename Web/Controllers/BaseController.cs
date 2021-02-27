using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly ILogger<HomeController> _logger;
        protected readonly EwalletContext db;
        protected int UserId { get
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return userId;
            }
        }
        public BaseController(ILogger<HomeController> logger, EwalletContext db)
        {
            _logger = logger;
            this.db = db;
        }
    }
}
