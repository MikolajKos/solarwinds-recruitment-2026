using swi;

OperationDb.Deserialize("input.json");
var db = OperationDb.database;

foreach (var item in db)
{
    var result = OperationFactory.GenerateOperation(item.Value).Calculate();

    Console.WriteLine($"{item.Key}: {result}");
}
