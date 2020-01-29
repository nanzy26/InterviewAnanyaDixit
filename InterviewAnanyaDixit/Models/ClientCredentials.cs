using System.Collections.Generic;

namespace InterviewAnanyaDixit.Controllers
{
    [ToString]
    public class ClientCredentials
    {
        public string access_token { get; set; }
        public long expires_in { get; set; }
        public string token_type { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ClientCredentials credentials &&
                   access_token == credentials.access_token &&
                   expires_in == credentials.expires_in &&
                   token_type == credentials.token_type;
        }

        public override int GetHashCode()
        {
            var hashCode = -1496902277;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(access_token);
            hashCode = hashCode * -1521134295 + expires_in.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(token_type);
            return hashCode;
        }
    }
}