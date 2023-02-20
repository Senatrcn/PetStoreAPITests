using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStoreAPITests.Models.User
{
    public class GetUserResponse
    {

        [JsonPropertyName("id")]
        public Int64 Id { get; set; }

        [JsonPropertyName("username")]
        public string UserName { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("userstatus")]
        public Int32 UserStatus { get; set; }
    }
}
