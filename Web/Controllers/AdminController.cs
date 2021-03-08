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
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        public AdminController(ILogger<HomeController> logger, EwalletContext db) : base(logger, db)
        { }

        public IActionResult ApplicationsView()
        {
            var viewOperator = from app in db.CardOrders
                               select
                               (new CardAppViewOperator
                               {
                                   UserId = app.UserId,
                                   OperatorId = app.OperatorId.ToString(),
                                   NameCard = app.NameCard,
                                   Сurrency = app.Сurrency == Currency.KGS ? "KGS" : "Not specified",
                                   CardType = app.CardType == CardType.Elcard ? "Elcard" : app.CardType == CardType.MasterCard ? "Master Card" : "Visa",
                                   Status = app.Status == CardStatus.Approved ? "Approved" : app.Status == CardStatus.Considering ? "Considering" : "Denied",
                                   Description = app.Description,
                                   CreatedDate = app.CreatedDate,
                                   DecisionDate = app.DecisionDate
                               }
                               );


            return View(viewOperator);
        }
    }
}
