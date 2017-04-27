using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracto.Apm.Models
{
    public class ExceptionDetails
    {
        private string _typeName;
        private string _source;
        private string _message;
        private string _detail;

        public ExceptionDetails(Exception exception)
        {
            _detail = exception.ToString();
            _message = exception.Message;
            _source = exception.Source;
            _typeName = exception.GetType().FullName;
        }

        [JsonProperty("type")]
        public string Type
        {
            get { return _typeName ?? string.Empty; }
        }

        [JsonProperty("source")]
        public string Source
        {
            get { return _source ?? string.Empty; }
        }

        [JsonProperty("message")]
        public string Message
        {
            get { return _message ?? string.Empty; }
        }

        [JsonProperty("detail")]
        public string Detail
        {
            get { return _detail ?? string.Empty; }
        }
    }
}
