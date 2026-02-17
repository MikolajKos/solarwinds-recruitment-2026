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
        public static Dictionary<string, SingleOperation>? database;

        public static void Deserialize(string file)
        {
            try
            {
                string jsonContent = File.ReadAllText(file);
                database = JsonSerializer.Deserialize<Dictionary<string, SingleOperation>>(jsonContent);
            }
            catch 
            {
                throw new Exception("Could not deserialize from json file");
            }
        }
    }
}
