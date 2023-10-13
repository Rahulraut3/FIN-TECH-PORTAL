using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using IBS_DALayer.Models;
using IBS_RSLayer;
using System.Collections.Generic;
using System;

namespace IBS_UILayer.Controllers.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionReportApiController : ControllerBase
    {
        private ICustomerDb<TransactionReport> ReportDb;

        public TransactionReportApiController(ICustomerDb<TransactionReport> reportDb)
        {
            ReportDb = reportDb;
        }


        /// <summary>
        /// To Show All Transactions to admin performed under IBS
        /// </summary>
        /// <returns>List of All Transaction</returns>
        [HttpGet("ShowAllTransaction")]
        public IActionResult ShowAllTransaction()
        {
            try
            {

                IEnumerable<TransactionReport> report = ReportDb.ShowAll();
                
                return Ok(report);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// To Dsiplay Transaction Details of a specific Account
        /// </summary>
        /// <param name="AccountNumber">Account no to check transactions of</param>
        /// <returns>List of Transaction made by Specific Account number</returns>
        [HttpGet("TransactionByAccNo/{AccountNumber}")]
        public IActionResult TransactionByAccNo(int AccountNumber)
        {
            try
            {

                IEnumerable<TransactionReport> report = ReportDb.ShowAllById(AccountNumber);
                if (report == null)
                {
                    return BadRequest("Something went wrong");
                }
                return Ok(report);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
