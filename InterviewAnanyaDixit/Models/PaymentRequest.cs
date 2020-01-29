using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InterviewAnanyaDixit.Controllers
{
    [ToString]
    public class PaymentRequest : IEquatable<PaymentRequest>
    {
        public BaseRequest baseRequest { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as PaymentRequest);
        }

        public bool Equals(PaymentRequest other)
        {
            return other != null &&
                   EqualityComparer<BaseRequest>.Default.Equals(baseRequest, other.baseRequest) &&
                   client_id == other.client_id &&
                   client_secret == other.client_secret;
        }

        public override int GetHashCode()
        {
            var hashCode = -1426110374;
            hashCode = hashCode * -1521134295 + EqualityComparer<BaseRequest>.Default.GetHashCode(baseRequest);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(client_id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(client_secret);
            return hashCode;
        }
    }
}