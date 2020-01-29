using InterviewAnanyaDixit.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewAnanyaDixit.Models
{
    [ToString]
    public class APIResponse : IEquatable<APIResponse>
    {
        public List<Result> results { get; set; }
        public string status { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as APIResponse);
        }

        public bool Equals(APIResponse other)
        {
            return other != null &&
                   EqualityComparer<List<Result>>.Default.Equals(results, other.results) &&
                   status == other.status;
        }

        public override int GetHashCode()
        {
            var hashCode = 859492908;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Result>>.Default.GetHashCode(results);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(status);
            return hashCode;
        }
    }

    [ToString]
    public class Result : IEquatable<Result>
    {
        public string simp_id { get; set; }
        public string auth_uri { get; set; }
        public DateTime created_at { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public string beneficiary_reference { get; set; }
        public string beneficiary_name { get; set; }
        public string beneficiary_sort_code { get; set; }
        public string beneficiary_account_number { get; set; }
        public string remitter_reference { get; set; }
        public string redirect_uri { get; set; }
        public string status { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Result);
        }

        public bool Equals(Result other)
        {
            return other != null &&
                   simp_id == other.simp_id &&
                   auth_uri == other.auth_uri &&
                   //created_at == other.created_at &&
                   amount == other.amount &&
                   currency == other.currency &&
                   beneficiary_reference == other.beneficiary_reference &&
                   beneficiary_name == other.beneficiary_name &&
                   beneficiary_sort_code == other.beneficiary_sort_code &&
                   beneficiary_account_number == other.beneficiary_account_number &&
                   remitter_reference == other.remitter_reference &&
                   redirect_uri == other.redirect_uri &&
                   status == other.status;
        }

        public override int GetHashCode()
        {
            var hashCode = 477303527;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(simp_id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(auth_uri);
            //hashCode = hashCode * -1521134295 + created_at.GetHashCode();
            hashCode = hashCode * -1521134295 + amount.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(currency);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(beneficiary_reference);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(beneficiary_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(beneficiary_sort_code);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(beneficiary_account_number);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(remitter_reference);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(redirect_uri);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(status);
            return hashCode;
        }
    }
}