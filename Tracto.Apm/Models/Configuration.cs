using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracto.Apm.Models
{
    public class Configuration
    {
        private String _publicKey;
        private String _privateKey;
        private String _environment;

        public Configuration()
        {
        }

        [JsonProperty("environment")]
        public String Environment
        {
            get { return _environment; }
            set { _environment = value.ToLower(); }
        }

        [JsonProperty("key")]
        public String PublicKey
        {
            get { return _publicKey; }
            set { _publicKey = value; }
        }

        [JsonIgnore]
        public String PrivateKey
        {
            get { return _privateKey; }
            set { _privateKey = value; }
        }

        [JsonIgnore]
        public String EndPoint
        {
            get { return "https://api.tracto.io/api/1.0/"; }
        }
    }
}
