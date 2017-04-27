using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracto.Apm.Models
{
    public class User
    {
        private string _name;
        private string _email;

        [JsonProperty("name")]
        public string Name
        {
            get { return _name ?? string.Empty; }
            set { _name = value; }
        }

        [JsonProperty("email")]
        public string Email
        {
            get { return _email ?? string.Empty; }
            set { _email = value; }
        }
    }
}
