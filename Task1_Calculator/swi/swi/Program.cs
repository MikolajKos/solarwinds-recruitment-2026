using System.Text.Json;
using swi;

try
{  
    Dictionary<string, SingleOperation> operations = OperationDb.Deserialize("input.json");
    Dictionary<string, double> results = new Dictionary<string, double>();

    // Calculating and writing to a Dictionary
    foreach (var item in operations)
    {
        try
        {
            var res = OperationFactory.GenerateOperation(item.Value).Calculate();
            results.Add(item.Key, res);
        }
        catch (ArgumentException ex) 
        {
            Console.WriteLine("Incorrect argument was passed: " + ex.Message);
        }
        catch (ArithmeticException ex)
        {
            Console.WriteLine("Forbidden math operation: " + ex.Message);
        }
    }

    // Saving result in output.txt
    ResultWriter resWrt = new ResultWriter();
    resWrt.SaveResult(results);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
catch (JsonException ex)
{ 
    Console.WriteLine("Json error occurred: " + ex.Message);
}
catch (FileNotFoundException ex)
{
    Console.WriteLine("File error occurred: " + ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("Unknown exception occurred: " + ex.ToString());
}