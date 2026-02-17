using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace swi
{
    public class SingleOperation
    {
        [JsonPropertyName("operator")]
        public string OperationType { get; set; } = string.Empty;

        [JsonPropertyName("value1")]
        public double Value1 { get; set; }

        [JsonPropertyName("value2")]
        public double? Value2 { get; set; }
    }
}
