using System.Text.Json.Serialization;

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
