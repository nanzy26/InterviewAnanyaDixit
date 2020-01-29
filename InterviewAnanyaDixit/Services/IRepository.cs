using InterviewAnanyaDixit.Models;
using System.Collections.Generic;

namespace InterviewAnanyaDixit.Controllers
{
    public interface IRepository
    {
        string PaymentsSandbox { get; set; }
        string RedirectUri { get; set; }
        string AuthUrl { get; set; }
        string FilePath { get; set; }
        List<Transaction> AllData { get; set; }
        CsvHelper.Configuration.CsvConfiguration CsvConfiguration { get; set; }

        ClientCredentials GetClientCredentials(string client_id, string client_secret);

        APIResponse CreatePayment(PaymentRequest request);

        string Callback(string payment_id);

        List<Transaction> GetTransactionsForBeneficiaryAccount(string beneficiary_account_number);

        List<AggregateData> GetAggregatedAmounts(string beneficiary_account_number);
    }
}