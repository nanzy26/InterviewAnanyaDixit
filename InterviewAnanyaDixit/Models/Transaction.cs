using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewAnanyaDixit.Models
{
    public class Transaction : IEquatable<Transaction>
    {
        public string simp_id { get; set; }
        public int amount { get; set; }
        public string beneficiary_account_number { get; set; }
        public string beneficiary_sort_code { get; set; }
        public string beneficiary_name { get; set; }
        public string status { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Transaction);
        }

        public bool Equals(Transaction other)
        {
            return other != null &&
                   simp_id == other.simp_id &&
                   amount == other.amount &&
                   beneficiary_account_number == other.beneficiary_account_number &&
                   beneficiary_sort_code == other.beneficiary_sort_code &&
                   beneficiary_name == other.beneficiary_name &&
                   status == other.status;
        }

        public override int GetHashCode()
        {
            var hashCode = 93733623;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(simp_id);
            hashCode = hashCode * -1521134295 + amount.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(beneficiary_account_number);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(beneficiary_sort_code);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(beneficiary_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(status);
            return hashCode;
        }
    }

    public class AggregateData : IEquatable<AggregateData>
    {
        public int min { get; set; }
        public int max { get; set; }
        public double average { get; set; }
        public string status { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as AggregateData);
        }

        public bool Equals(AggregateData other)
        {
            return other != null &&
                   min == other.min &&
                   max == other.max &&
                   average == other.average &&
                   status == other.status;
        }

        public override int GetHashCode()
        {
            var hashCode = -320619041;
            hashCode = hashCode * -1521134295 + min.GetHashCode();
            hashCode = hashCode * -1521134295 + max.GetHashCode();
            hashCode = hashCode * -1521134295 + average.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(status);
            return hashCode;
        }
    }
}