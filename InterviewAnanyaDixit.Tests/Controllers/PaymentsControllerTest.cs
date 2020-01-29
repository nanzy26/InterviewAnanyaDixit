using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewAnanyaDixit.Controllers;
using InterviewAnanyaDixit.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InterviewAnanyaDixit.Tests.Controllers
{
    [TestClass]
    public class PaymentsControllerTest
    {
        PaymentsController controller;
        Mock<IRepository> mockRepo;

        [TestInitialize]
        public void Setup()
        {
            mockRepo = new Mock<IRepository>();
            controller = new PaymentsController(mockRepo.Object);
        }

        [TestMethod]
        public void TestGetAuthorisation()
        {
            //arrange
            mockRepo.Setup(repo => repo.GetClientCredentials("123", "456")).Returns(ExpectedCredentials());

            //act
            var result = controller.GetClientCredentials("123", "456");

            //assert
            Assert.AreEqual(ExpectedCredentials(), result);
        }

        [TestMethod]
        public void TestCreatePayment()
        {         
            PaymentRequest request = new PaymentRequest();
            BaseRequest baseRequest = new BaseRequest
            {
                access_token = "1234567890",
                amount = 1000,
                beneficiary_account_number = "10000000",
                beneficiary_name = "test-user",
                beneficiary_reference = "test-ref",
                beneficiary_sort_code = "12345678",
                currency = "GBP",
                redirect_uri = "https:redirect.com",
                remitter_reference = "remit - ref",
            };
            request.baseRequest = baseRequest;

            mockRepo.Setup(repo => repo.CreatePayment(request)).Returns(ExpectedResponse());

            var result = controller.CreatePayment(request);
            var expected = ExpectedResponse();

            Assert.AreEqual(result.results.Count, expected.results.Count);
            for (int i = 0; i < result.results.Count; ++i)
            {
                Assert.AreEqual(result.results[i], expected.results[i]);
            }
            
        }

        [TestMethod]
        public void TestCallback()
        {         
            string payment_id = "abcd-1234";
            mockRepo.Setup(repo => repo.Callback("abcd-1234")).Returns("success: abcd-1234");
            
            var result = controller.callback(payment_id);

            Assert.AreEqual("success: " + payment_id, result);
        }

        [TestMethod]
        public void TestGetTransactionsForBeneficiaryName()
        {
            mockRepo.Setup(repo => repo.GetTransactionsForBeneficiaryAccount("10000000")).Returns(ExpectedTransactions());
            
            var result= controller.GetTransactionsForBeneficiaryAccount("10000000");
            var expected = ExpectedTransactions();
            Assert.AreEqual(result.Count, expected.Count);
            for (int i = 0; i < result.Count; ++i)
            {
                Assert.AreEqual(result[i], expected[i]);
            }
        }

        [TestMethod]
        public void TestGetAggregatedAmountsByStatus()
        {
            mockRepo.Setup(repo => repo.GetAggregatedAmounts("10000000")).Returns(ExpectedAggData());
            var result = controller.GetAggregatedAmounts("10000000");

            var expected = ExpectedAggData();
            Assert.AreEqual(expected.Count, result.Count);

            for (int i = 0; i < result.Count; ++i)
            {
                Assert.AreEqual(result[i], expected[i]);
            }
        }

        private ClientCredentials ExpectedCredentials()
        {
            return new ClientCredentials()
            {
                access_token = "1234567890",
                expires_in = 3600,
                token_type = "test"
            };
        }

        private APIResponse ExpectedResponse()
        {
            var results = new List<Result>();
            results.Add(new Result()
            {
                amount = 1000,
                auth_uri = "https:test.com",
                beneficiary_account_number = "10000000",
                beneficiary_name = "test-user",
                beneficiary_reference = "test-ref",
                beneficiary_sort_code = "12345678",
                created_at = DateTime.Parse("2020-01-26T00:00:00.0000000Z"),
                currency = "GBP",
                redirect_uri = "https:redirect.com",
                remitter_reference = "remit - ref",
                simp_id = "1234-abcd",
                status = "new"
            });
            return new APIResponse() { results = results, status = "successful" };
        }

        private List<Transaction> ExpectedTransactions()
        {
            var transactions = new List<Transaction>();
            transactions.Add(new Transaction()
            {
                amount = 1000,
                beneficiary_account_number = "10000000",
                beneficiary_name = "test-user",
                beneficiary_sort_code = "012131",
                simp_id = "1234-abcd",
                status = "submitted"
            });
            return transactions;
        }

        private List<AggregateData> ExpectedAggData()
        {
            var data = new List<AggregateData>();
            data.Add(new AggregateData()
            {
                average = 1500,
                max = 2000,
                min = 1000,
                status = "new"
            });
            return data;
        }
    }
}
