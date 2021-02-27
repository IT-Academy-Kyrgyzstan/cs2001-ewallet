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

        public async Task<IActionResult> Transfer()
        {
            var userCards = await db.CardAccounts.Where(u => u.UserId == UserId).ToArrayAsync();

            return View(userCards);
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(string selectCardNumber, string transferCardNumber, decimal transferBalance)
        {
            var userCardView = db.CardAccounts.Where(u => u.UserId == UserId);

            var userCard = await userCardView.FirstOrDefaultAsync(u => u.CardNumber == selectCardNumber);
            var transferCard = await db.CardAccounts.FirstOrDefaultAsync(u => u.CardNumber == transferCardNumber);

            if (userCard == null || transferCard == null)
            {
                ModelState.AddModelError("ErrorMessage_Id", "Сard number not found");

                return View(userCardView);
            }

            if (userCard.CardBalance < transferBalance || transferBalance <= 0)
            {
                ModelState.AddModelError("ErrorMessage_Id", "Insufficient funds, top up balance");

                return View(userCardView);
            }

            userCard.CardBalance = userCard.CardBalance - transferBalance;
            transferCard.CardBalance = transferCard.CardBalance + transferBalance;

            await db.SaveChangesAsync();

            return View(userCardView);
        }

        public async Task<IActionResult> CheckCardNumber([FromQuery] string cardNumber)
        {
            var cardAccount = await db.CardAccounts.FirstOrDefaultAsync(c => c.CardNumber == cardNumber);

            if (cardAccount == null) return NotFound("Account was not found");

            var user = await db.Users.FindAsync(cardAccount.UserId);
            
            return Ok(new { user.UserName, user.FirstName, user.LastName, cardAccount.StatusId });
        }
    }
}
