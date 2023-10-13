using IBS_DALayer.Models;
using IBS_RSLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IBS_UILayer.Controllers.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyTransactionApiController : ControllerBase
    {
        private ICustomerDb<AccountDetail> Cdb;
        private ICustomerDb<TransactionReport> Tdb;

        public MoneyTransactionApiController(ICustomerDb<AccountDetail> cdb, ICustomerDb<TransactionReport> tdb)
        {
            Cdb = cdb;
            Tdb = tdb;
        }

        /// <summary>
        /// To Deposit Money into Customers bank account
        /// </summary>
        /// <param name="DAccountNumber"> account no</param>
        /// <param name="Amount">Amount to be sent</param>
        /// <returns></returns>
        [HttpGet("Deposit/{DAccountNumber},{Amount}")]
        public IActionResult Deposit(int DAccountNumber, int Amount)
        {
            try
            {
                AccountDetail accountDetail = Cdb.GetById(DAccountNumber);
                int CurrentBalance = (int)accountDetail.AccountBalance;
                accountDetail.AccountBalance = CurrentBalance + Amount;
                Cdb.Update(accountDetail);

                //Adding Transaction in TransactionReport Table for Deposit
                TransactionReport transaction = new TransactionReport();
                transaction.SenderAccountNo = DAccountNumber;
                transaction.Amount = Amount;
                transaction.RecieverAccountNo = 0;
                transaction.TransactionType = "Deposit";
                transaction.DateOfTransaction = System.DateTime.Now;
                Tdb.Add(transaction);

                return Ok(accountDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// To withdrawal Money From Account
        /// </summary>
        /// <param name="WAccountNumber"> Account number to perform withdrawl on</param>
        /// <param name="Amount">Amount to be withdrawaled</param>
        /// <returns></returns>
        [HttpGet("Withdrawal/{WAccountNumber},{Amount}")]
        public IActionResult Withdrawal(int WAccountNumber, int Amount)
        {
            try
            {
                AccountDetail accountDetail = Cdb.GetById(WAccountNumber);
                int CurrentBalance = (int)accountDetail.AccountBalance;
                accountDetail.AccountBalance = CurrentBalance - Amount;
                if (accountDetail.AccountBalance < 3000)
                {
                    return BadRequest("Transaction Not procesed");
                }
                Cdb.Update(accountDetail);

                //Adding Transaction in TransactionReport Table for Withdrawal

                TransactionReport transaction = new TransactionReport();
                transaction.SenderAccountNo = WAccountNumber;
                transaction.Amount = Amount;
                transaction.RecieverAccountNo = 0;
                transaction.TransactionType = "Withdraw";
                transaction.DateOfTransaction = System.DateTime.Now;
                Tdb.Add(transaction);

                return Ok(accountDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        /// <summary>
        /// To Transfer Money To another account no
        /// </summary>
        /// <param name="AccountNumber">Account no of Sender</param>
        /// <param name="Amount">Amount to be Transferred</param>
        /// <param name="RecipientAccountNumber">Receivers Account No</param>
        /// <returns></returns>
        [HttpGet("MoneyTransfer/{AccountNumber},{Amount},{RecipientAccountNumber}")]
        public IActionResult MoneyTransfer(int AccountNumber, int Amount, int RecipientAccountNumber)
        {
            try
            {
                AccountDetail accountDetail = Cdb.GetById(AccountNumber);
                int CurrentBalance = (int)accountDetail.AccountBalance;
                accountDetail.AccountBalance = CurrentBalance - Amount;
                if (accountDetail.AccountBalance < 3000)
                {
                    return BadRequest("Transaction Not procesed");
                }

                AccountDetail raccountDetail = Cdb.GetById(RecipientAccountNumber);
                if (raccountDetail == null)
                {
                    return BadRequest("Account Not Found");
                }
                int RCurrentBalance = (int)raccountDetail.AccountBalance;
                raccountDetail.AccountBalance = RCurrentBalance + Amount;

                Cdb.Update(accountDetail);
                Cdb.Update(raccountDetail);

                //Adding Transaction in TransactionReport Table for Money Transfer

                TransactionReport transaction = new TransactionReport();
                transaction.SenderAccountNo = AccountNumber;
                transaction.Amount = Amount;
                transaction.RecieverAccountNo = RecipientAccountNumber;
                transaction.TransactionType = "Money Transfer";
                transaction.DateOfTransaction = System.DateTime.Now;
                Tdb.Add(transaction);

                return Ok(accountDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        /// <summary>
        /// To check Balance of Customer
        /// </summary>
        /// <param name="AccountNumber">Account no of which balance has to be checked</param>
        /// <returns>Balance</returns>
        [HttpGet("CheckBalance/{AccountNumber}")]
        public IActionResult CheckBalance(int AccountNumber)
        {
            
            AccountDetail accountDetail = Cdb.GetById(AccountNumber);
            return Ok(accountDetail);
            //return Content(accountDetail.AccountBalance.ToString());
        }


    }
}
