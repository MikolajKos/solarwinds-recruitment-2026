using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace swi
{
    public class ResultWriter
    {
        private readonly string _filePath;

        public ResultWriter(string filePath = "output.txt")
        {
            _filePath = filePath;
        }

        public void SaveResult(Dictionary<string, double> data)
        {
            var linesToWrite = GetResultLines(data);
            File.WriteAllLines(_filePath, linesToWrite);
        }

        private List<string> GetResultLines(Dictionary<string, double> data, bool sort = true)
        {
            var result = new List<string>();
            IEnumerable<KeyValuePair<string, double>> source = data;

            if (sort)
                source = data.OrderBy(x => x.Value);

            foreach (var item in source)
                result.Add($"{item.Key}: {item.Value}");

            return result;
        }
    }
}
