using Flurl.Http;
using CsvHelper;
using InterviewAnanyaDixit.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Globalization;
using System.IO;

namespace InterviewAnanyaDixit.Controllers
{
    public class PaymentsController : ApiController
    {
        private IRepository paymentsRepository;

        public PaymentsController() { paymentsRepository = new PaymentsRepository(); }

        public PaymentsController(IRepository paymentsRepository)
        {
            this.paymentsRepository = paymentsRepository;
        }

        [HttpPost]
        [Route("api/Payments/GetClientCredentials")]
        [ActionName("GetClientCredentials")]
        public ClientCredentials GetClientCredentials(string client_id, string client_secret)
        {           
            return paymentsRepository.GetClientCredentials(client_id, client_secret);
        }
        
        [HttpPost]
        [Route("api/Payments/CreatePayment")]
        [ActionName("CreatePayment")]
        public APIResponse CreatePayment(PaymentRequest request)
        {
            return paymentsRepository.CreatePayment(request);
        }

        [HttpGet]
        [Route("api/Payments/callback")]
        [ActionName("callback")]
        public string callback(string payment_id)
        {
            return paymentsRepository.Callback(payment_id);
        }

        [HttpGet]
        [Route("api/Payments/GetTransactions")]
        [ActionName("GetTransactions")]
        public List<Transaction> GetTransactionsForBeneficiaryAccount(string beneficiary_account_number)
        {
            return paymentsRepository.GetTransactionsForBeneficiaryAccount(beneficiary_account_number);
        }

        [HttpGet]
        [Route("api/Payments/GetAggregatedAmounts")]
        [ActionName("GetAggregatedAmounts")]
        public List<AggregateData> GetAggregatedAmounts(string beneficiary_account_number)
        {
            return paymentsRepository.GetAggregatedAmounts(beneficiary_account_number);
        }


    }

}
