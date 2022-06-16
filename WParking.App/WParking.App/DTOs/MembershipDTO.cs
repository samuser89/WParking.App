
using Newtonsoft.Json;

namespace WParking.App.DTOs
{
    public class MembershipDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        public string NameMembership { get; set; }
        public string StatusMembership { get; set; }
    }
}
