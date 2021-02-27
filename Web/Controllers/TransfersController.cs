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
            var viewModel = new TransferViewModel
            {
                CardAccounts = userCards
            };
                   
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(TransferViewModel transferViewModel)
        {
            var userCardView = db.CardAccounts.Where(u => u.UserId == UserId);

            var userCard = await userCardView.FirstOrDefaultAsync(u => u.CardNumber == transferViewModel.SelectCardNumber);
            var transferCard = await db.CardAccounts.FirstOrDefaultAsync(u => u.CardNumber == transferViewModel.TransferCardNumber);

            transferViewModel.CardAccounts = userCardView;



            if (userCard == null || transferCard == null)
            {
                ModelState.AddModelError("ErrorMessage_Id", "Сard number not found");

                return View(transferViewModel);
            }

            if (userCard.CardBalance < transferViewModel.TransferBalance || transferViewModel.TransferBalance <= 0)
            {
                ModelState.AddModelError("ErrorMessage_Id", "Insufficient funds, top up balance");

                return View(transferViewModel);
            }
            using(var transaction = await db.Database.BeginTransactionAsync())
            {
                userCard.CardBalance = userCard.CardBalance - transferViewModel.TransferBalance;
                transferCard.CardBalance = transferCard.CardBalance + transferViewModel.TransferBalance;

                await db.SaveChangesAsync();
                await transaction.CommitAsync();
            }

            TempData["SuccessMessage"] = $"Перевод успешно отправлен на сумму {transferViewModel.TransferBalance} KGS.";


            return RedirectToAction("Transfer");
        }
    }
}
