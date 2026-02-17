using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
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

    public static class OperationDb
    {
        public static Dictionary<string, SingleOperation>? database;

        public static void Deserialize(string file)
        {
            string jsonContent = File.ReadAllText(file);
            database = JsonSerializer.Deserialize<Dictionary<string, SingleOperation>>(jsonContent);
        }
    }
}
