using RickAndMortyApi.Services;

namespace RickAndMortyApi.Tests
{
    public class CreateBatchesTest
    {
        public static IEnumerable<object[]> GetBatches()
        {
            yield return new object[] { string.Join(",", Enumerable.Range(1, 20)), 10, 2, 10 };

            yield return new object[] { string.Join(",", Enumerable.Range(1, 127)), 20, 7, 7 };

            yield return new object[] { string.Join(",", Enumerable.Range(1, 5021)), 50, 101, 21 };
        }

        [Theory]
        [MemberData(nameof(GetBatches))]
        public void CreateBatches_ShouldSplitQuery_IntoSmallerBatches(string ids, int maxBatchSize, int expectedCount, int expectedLastCount)
        {
            var batches = RickAndMortyService.CreateBatches(ids, maxBatchSize);

            var lastBatch = batches.Last();

            Assert.Equal(lastBatch.Split(',').Count(), expectedLastCount);
            Assert.Equal(batches.Count(), expectedCount);
        }
    }
}