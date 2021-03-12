using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;

namespace Web.Controllers
{
    public class AdminController : BaseController
    {
        public AdminController(ILogger<HomeController> logger, EwalletContext db) : base(logger, db)
        { }

        [Authorize(Roles = "Operator")]
        public IActionResult ApplicationsOperatorVM()
        {
            var viewOperator = from app in db.CardOrders
                               select
                               (new CardApplicationsOperatorVM
                               {
                                   Id = app.Id,
                                   UserId = app.UserId,
                                   Сurrency = app.Сurrency == Currency.KGS ? "KGS" : "Not specified",
                                   CardType = app.CardType == CardType.Elcard ? "Elcard" : app.CardType == CardType.MasterCard ? "Master Card" : "Visa",
                                   Status = app.Status == CardStatus.Approved ? "Approved" : app.Status == CardStatus.Considering ? "Considering" : "Denied",
                                   CreatedDate = app.CreatedDate,
                               }
                               );

            return View(viewOperator);
        }
    }
}