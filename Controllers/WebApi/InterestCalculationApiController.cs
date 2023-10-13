using IBS_DALayer.Models;
using IBS_RSLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IBS_UILayer.Controllers.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestCalculationApiController : ControllerBase
    {

        private ICustomerDb<AccountDetail> AccDb;
        private ICustomerDb<TransactionReport> TransDb;

        public InterestCalculationApiController(ICustomerDb<AccountDetail> accDb, ICustomerDb<TransactionReport> transDb)
        {
            AccDb = accDb;
            TransDb = transDb;
        }


        /// <summary>
        /// This Function is executed when admin wants to Calculate interest
        /// </summary>
        /// <param name="AccountNumber">Account number to determine the type of Customer</param>
        /// <returns>Updated Balance</returns>
        [HttpGet("CalculateInterest/{AccountNumber}")]
        public IActionResult CalculateInterest(int AccountNumber)
        {
            try
            {
                AccountDetail rec = AccDb.GetById(AccountNumber);
                if (rec == null)
                {
                    return NotFound("Account not Found");
                }
                double AccountBalance = (double)rec.AccountBalance;
                string AccountType = (string)rec.AccountType;
                DateTime AccountCreationDate = (DateTime)rec.AccountCreationDate;

                DateTime LastCalculatedInterestDate = (DateTime)rec.LastCalculatedInterestDate;
                DateTime CurrentDate = DateTime.Now;

                int month = ((CurrentDate.Year - LastCalculatedInterestDate.Year) * 12) + CurrentDate.Month - LastCalculatedInterestDate.Month;
                int year = CurrentDate.Year - LastCalculatedInterestDate.Year;
                double InterestBalance = 0D;

                if (AccountType == "Saving")
                {
                    InterestBalance = (AccountBalance * (month / 12) * 5) / 100;
                }
                else if (AccountType == "Fixed")
                {
                    InterestBalance = (AccountBalance * year * 10) / 100;
                }
                rec.AccountBalance = (decimal)(InterestBalance + AccountBalance);
                rec.LastCalculatedInterestDate = CurrentDate;
                AccDb.Update(rec);

                TransactionReport transaction = new TransactionReport();
                transaction.SenderAccountNo = AccountNumber;
                transaction.Amount = (int)InterestBalance;
                transaction.RecieverAccountNo = 0;
                transaction.TransactionType = "Interest";
                transaction.DateOfTransaction = System.DateTime.Now;
                TransDb.Add(transaction);

                return Ok(rec);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
