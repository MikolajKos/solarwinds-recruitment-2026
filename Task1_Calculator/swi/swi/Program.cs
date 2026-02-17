using swi;

OperationDb.Deserialize("input.json");
var db = OperationDb.database;

if (db == null) { return; }

foreach (var item in db)
{
    Console.WriteLine(item.Key);
}
