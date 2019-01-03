using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MSEADEW.Providers
{
    public class Token
    {

        [JsonProperty("Access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("RoleId")]
        public string RoleId { get; set; }
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }
        [JsonProperty("LastName")]
        public string LastName { get; set; }
        [JsonProperty("UserId")]
        public string UserId { get; set; }
    }

}