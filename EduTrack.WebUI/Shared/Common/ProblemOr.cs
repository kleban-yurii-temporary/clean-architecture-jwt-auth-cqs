using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Common
{
    public class ProblemOr<T> 
    {
        public bool IsError { get { return this.Status != null; } }
        public T Value { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public int? Status { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> Extensions { get; } = new Dictionary<string, object>(StringComparer.Ordinal);
    }
}
