using CsvHelper;
using CsvHelper.Configuration;
using Flurl.Http;
using InterviewAnanyaDixit.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace InterviewAnanyaDixit.Models
{
    public class PaymentsRepository : IRepository
    {
        public string PaymentsSandbox { get; set; } = "https://pay-api.truelayer-sandbox.com/single-immediate-payments";
        public string RedirectUri { get; set; } = "https://localhost:44311/api/Payments/callback";
        public string AuthUrl { get; set; } = "https://auth.truelayer-sandbox.com/connect/token";
        public List<Transaction> AllData { get; set; } = new List<Transaction>();
        public string FilePath { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "Data.csv");
        public CsvConfiguration CsvConfiguration { get; set; } = new CsvConfiguration(CultureInfo.CurrentCulture);


        #region method impls
        public string Callback(string payment_id)
        {
            return "success: " + payment_id;
        }

        public APIResponse CreatePayment(PaymentRequest request)
        {
            APIResponse response = null;
            request.baseRequest.redirect_uri = RedirectUri;
            try
            {
                response = PaymentsSandbox.WithOAuthBearerToken(request.baseRequest.access_token).PostJsonAsync(request.baseRequest).ReceiveJson<APIResponse>().Result;
                //write to csv file
                foreach (var result in response.results)
                {
                    AllData.Add(new Transaction() { 
                        simp_id = result.simp_id, 
                        amount = result.amount, 
                        beneficiary_name = result.beneficiary_name, 
                        beneficiary_account_number = result.beneficiary_account_number, 
                        beneficiary_sort_code = result.beneficiary_sort_code, 
                        status = result.status });
                }
                if (File.Exists(FilePath))
                {
                    CsvConfiguration.HasHeaderRecord = false;
                }
                using (var writer = new StreamWriter(FilePath, true))
                {
                    using (var csv = new CsvWriter(writer, CsvConfiguration))
                    {
                        csv.WriteRecords(AllData);
                    }
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return response;

        }

        public List<AggregateData> GetAggregatedAmounts(string beneficiary_account_number)
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    CsvConfiguration.HasHeaderRecord = false;
                }
                using (var reader = new StreamReader(FilePath))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))
                    {
                        var allDataNew = csv.GetRecords<Transaction>().ToList();
                        var selected = from data in allDataNew where data.beneficiary_account_number.Equals(beneficiary_account_number) select data;
                        var ag = selected.ToList()
                            .GroupBy(i => i.status)
                            .Select(g => new
                            {
                                Average = g.Average(i => i.amount),
                                Max = g.Max(i => i.amount),
                                Min = g.Min(i => i.amount),
                                Status = g.Key
                            }).OrderByDescending(g => g.Status)
                            .ToList();

                        var agList = new List<AggregateData>();
                        ag.ForEach(a =>
                        {
                            var data = new AggregateData() { average = a.Average, max = a.Max, min = a.Min, status = a.Status };
                            agList.Add(data);
                        });
                        return agList;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return new List<AggregateData>();
        }

        public ClientCredentials GetClientCredentials(string client_id, string client_secret)
        {
            ClientCredentials ret = null;
            try
            {
                ret = AuthUrl.PostUrlEncodedAsync(new { client_id, client_secret, scope = "payments", grant_type = "client_credentials" }).ReceiveJson<ClientCredentials>().Result;
            }
            catch (FlurlHttpException e)
            {
                Debug.WriteLine(e.Message);
            }
            catch (Exception e1)
            {
                Debug.WriteLine(e1.Message);
            }
            return ret;
        }

        public List<Transaction> GetTransactionsForBeneficiaryAccount(string beneficiary_account_number)
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    CsvConfiguration.HasHeaderRecord = false;
                }
                using (var reader = new StreamReader(FilePath))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))
                    {
                        var allDataNew = csv.GetRecords<Transaction>().ToList();
                        var selected = from data in allDataNew where data.beneficiary_account_number.Equals(beneficiary_account_number) select data;
                        return selected.ToList();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return new List<Transaction>();
        }

        #endregion
    }
}