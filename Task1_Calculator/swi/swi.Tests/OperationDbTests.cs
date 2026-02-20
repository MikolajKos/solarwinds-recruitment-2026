namespace swi.Tests
{
    public class OperationDbTests
    {
        [Fact]
        public void Deserialize_ShouldThrowException_WhenJsonIsInvalid()
        {
            // Arange temporary json file
            string tempFilePath = Path.GetTempFileName();
            string badjson = "{ invalid json ";
            
            File.WriteAllText(tempFilePath, badjson);

            try
            {
                Assert.Throws<InvalidOperationException>(() => OperationDb.Deserialize(tempFilePath));
            }
            finally
            {
                // Free alocated resources
                File.Delete(tempFilePath);
            }
        }

        [Fact]
        public void Deserialize_ShouldReturnDictionary_WhenJsonIsValid ()
        {
            string tempFile = Path.GetTempFileName();
            string validJson = @"{
                ""obj1"": { ""operator"": ""add"", ""value1"": 2, ""value2"": 3 },
                ""obj2"": { ""operator"": ""mul"", ""value1"": 4, ""value2"": 5 }
            }";

            try
            {
                File.WriteAllText(tempFile, validJson);

                var dict = OperationDb.Deserialize(tempFile);

                Assert.NotNull(dict);
                Assert.True(dict.ContainsKey("obj1"));
                Assert.True(dict.ContainsKey("obj2"));
                Assert.Equal("add", dict["obj1"].OperationType);
                Assert.Equal("mul", dict["obj2"].OperationType);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }
    }
}