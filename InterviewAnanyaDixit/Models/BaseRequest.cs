using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InterviewAnanyaDixit.Controllers
{
    [ToString]
    public class BaseRequest : IEquatable<BaseRequest>
    {
        //some are optional
        //would put required=true
        [Required(ErrorMessage = "Amount is required")]
        public int amount { get; set; }
        [Required(ErrorMessage = "Currency is required")]
        public string currency { get; set; }
        [Required(ErrorMessage = "Remitter Reference is required")]
        public string remitter_reference { get; set; }
        [Required(ErrorMessage = "Beneficiary name is required")]
        public string beneficiary_name { get; set; }
        [Required(ErrorMessage = "Beneficiary sort code is required")]
        public string beneficiary_sort_code { get; set; }
        [Required(ErrorMessage = "Beneficiary account number is required")]
        public string beneficiary_account_number { get; set; }
        [Required(ErrorMessage = "Beneficiary reference is required")]
        public string beneficiary_reference { get; set; }
        [Required(ErrorMessage = "Redirect URI is required")]
        public string redirect_uri { get; set; }
        public string remitter_name { get; set; }
        public string remitter_sort_code { get; set; }
        public string remitter_account_number { get; set; }
        public string remitter_provider_id { get; set; }
        [Required(ErrorMessage = "Access token is required")]
        public string access_token { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as BaseRequest);
        }

        public bool Equals(BaseRequest other)
        {
            return other != null &&
                   amount == other.amount &&
                   currency == other.currency &&
                   remitter_reference == other.remitter_reference &&
                   beneficiary_name == other.beneficiary_name &&
                   beneficiary_sort_code == other.beneficiary_sort_code &&
                   beneficiary_account_number == other.beneficiary_account_number &&
                   beneficiary_reference == other.beneficiary_reference &&
                   redirect_uri == other.redirect_uri &&
                   remitter_name == other.remitter_name &&
                   remitter_sort_code == other.remitter_sort_code &&
                   remitter_account_number == other.remitter_account_number &&
                   remitter_provider_id == other.remitter_provider_id &&
                   access_token == other.access_token;
        }

        public override int GetHashCode()
        {
            var hashCode = -1868083311;
            hashCode = hashCode * -1521134295 + amount.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(currency);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(remitter_reference);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(beneficiary_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(beneficiary_sort_code);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(beneficiary_account_number);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(beneficiary_reference);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(redirect_uri);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(remitter_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(remitter_sort_code);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(remitter_account_number);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(remitter_provider_id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(access_token);
            return hashCode;
        }
    }
}