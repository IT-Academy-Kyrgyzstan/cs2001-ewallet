using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Web.Models;

namespace Web.Controllers
{
    public class TransfersController : BaseController
    {
        public TransfersController(ILogger<HomeController> logger, EwalletContext db) : base(logger, db)
        {
        }

        public IActionResult Transfer()
        {
            var userCard = db.CardAccounts.Where(u => u.UserId == UserId);

            return View(userCard);
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(string selectCardNumber, string transferCardNumber, decimal transferBalance)
        {
            var userCardView = db.CardAccounts.Where(u => u.UserId == UserId);

            var userCard = await userCardView.FirstOrDefaultAsync(u => u.CardNumber == selectCardNumber);
            var transferCard = await db.CardAccounts.FirstOrDefaultAsync(u => u.CardNumber == transferCardNumber);

            if (userCard != null && transferCard != null)
            {
                if (userCard.CardBalance >= transferBalance && transferBalance > 0)
                {
                    userCard.CardBalance = userCard.CardBalance - transferBalance;
                    transferCard.CardBalance = transferCard.CardBalance + transferBalance;

                    await db.SaveChangesAsync();

                    return View(userCardView);
                }
                ModelState.AddModelError("ErrorMessage_Id", "Insufficient funds, top up balance");
                return View(userCardView);
            }
            ModelState.AddModelError("ErrorMessage_Id", "Сard number not found");
            return View(userCardView);
        }
    }
}
