using System;
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
    [Authorize]
    public class TransferController : BaseController
    {
        public TransferController(ILogger<HomeController> logger, EwalletContext db) : base(logger, db)
        {
        }

        public IActionResult Transfer()
        {
            var userCard = db.CardAccounts.Where(u => u.UserId == GetUserId());
            ViewBag.Card = userCard;
            
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Transfer(CardAccountModel cardAccountmodel)
        {
            var userCard = await db.CardAccounts.FirstOrDefaultAsync(u => u.CardNumber == cardAccountmodel.SelectCardNumber);
            var transferCard = await db.CardAccounts.FirstOrDefaultAsync(u => u.CardNumber == cardAccountmodel.TransferCardNumber);




            var userCardForViewBag = db.CardAccounts.Where(u => u.UserId == GetUserId());
            ViewBag.Card = userCardForViewBag;

            if (transferCard != null)
            {
                if (userCard.CardBalance >= cardAccountmodel.TransferBalance && cardAccountmodel.TransferBalance > 0)
                {
                    userCard.CardBalance = userCard.CardBalance - cardAccountmodel.TransferBalance;
                    transferCard.CardBalance = transferCard.CardBalance + cardAccountmodel.TransferBalance;

                    await db.SaveChangesAsync();

                    return View();
                }
                ModelState.AddModelError("ErrorMessage_Id", "Insufficient funds, top up balance");
                return View();
            }
            ModelState.AddModelError("ErrorMessage_Id", "Сard number not found");
            return View();
        }

        [Produces("application/json")]
        public async Task<IActionResult> CheckCardNumber(string cardNumber)
        {
            var cardAccount = await db.CardAccounts.FirstOrDefaultAsync(c => c.CardNumber == cardNumber);
    
            if (cardAccount != null && cardAccount.StatusId == (int)Statuses.worked)
            {
                var user = await db.Users.FindAsync(cardAccount.UserId);
                return Ok($"{user.LastName} {user.FirstName}");
            }
            else
            {
                return NotFound("Account if blocked or does not exist");
            }
        }
    }
}
