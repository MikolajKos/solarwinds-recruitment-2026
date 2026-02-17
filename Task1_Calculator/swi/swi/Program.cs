using swi;

OperationDb.Deserialize("input.json");
var db = OperationDb.database;

foreach (var item in db)
{
    var result = OperationFactory.GenerateOperation(item.Value).Calculate();

    Console.WriteLine($"{item.Key} operation: {item.Value.OperationType}\n" +
        $"num1: {item.Value.Value1} num2: {item.Value.Value2 ?? 0}\n" +
        $"result: {result}\n");
}
