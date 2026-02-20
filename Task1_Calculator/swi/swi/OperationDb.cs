using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace swi
{
    public static class OperationDb
    {
        public static Dictionary<string, SingleOperation> Deserialize(string file)
        {
            if (!File.Exists(file))
            {
                throw new FileNotFoundException($"Could not find the desired file: {file}");
            }

            try
            {
                string jsonContent = File.ReadAllText(file);

                return JsonSerializer.Deserialize<Dictionary<string, SingleOperation>>(jsonContent) ?? 
                    throw new InvalidOperationException("JSON file is empty or it has invalid format");
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Error occured while parsing JSON file: {ex.Message}");
            }
        }
    }
}
