using System;

namespace InterviewAnanyaDixit.Controllers
{
    public class PaymentResponse
    {
        public BaseRequest request { get; set; }
        public string simp_id { get; set; }
        public string auth_uri { get; set; }
        public string status { get; set; }
    }
}