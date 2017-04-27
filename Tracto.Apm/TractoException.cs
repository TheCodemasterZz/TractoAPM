using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Tracto.Apm.Models;

namespace Tracto.Apm
{
    [Serializable]
    public class TractoException
    {

        private static readonly string NotifierAssemblyVersion = typeof(TractoException).Assembly.GetName().Version.ToString(3);

        private String _applicationName;

        private Configuration _configuration;
        private ExceptionDetails _exceptionDetails;
        private User _user;

        public TractoException() { }

        public TractoException(Exception exception) : 
            this(exception, null) { }

        public TractoException(Exception exception, HttpContextBase context)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            _exceptionDetails = new ExceptionDetails(exception.GetBaseException());
        }

        public TractoException Send()
        {
            return this;
        }

        [JsonProperty("id")]
        public String Id
        {
            get { return Guid.NewGuid().ToString(); }
        }

        [JsonProperty("timestamp")]
        public long Timestamp
        {
            get { return (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds; }
        }

        [JsonProperty("application")]
        public string ApplicationName
        {
            get { return _applicationName ?? string.Empty; }
            set { _applicationName = value; }
        }

        [JsonProperty("user")]
        public User User
        {
            get { return _user ?? new User(); }
            set { _user = value; }
        }

        [JsonProperty("exception")]
        public ExceptionDetails ExceptionDetails
        {
            get { return _exceptionDetails; }
        }

        [JsonProperty("configuration")]
        public Configuration Configuration
        {
            get { return _configuration; }
            set { _configuration = value; }
        }

        [JsonProperty("notifier", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Dictionary<string, string> Notifier
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "name", "Tracto.Net" },
                    { "version", NotifierAssemblyVersion },
                };
            }
        }

    }
}
