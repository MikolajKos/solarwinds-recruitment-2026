using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RickAndMortyApi.Services;

namespace RickAndMortyApi.Tests
{
    public class SortAndLimitTheScopeTest
    {
        public static IEnumerable<object[]> GetTestCases()
        {
            // sorting test case
            yield return new object[] { 
                // input pairs
                new Dictionary<(string, string), int>
                {
                    { ("url1", "url2"), 7 },
                    { ("url3", "url4"), 10 },
                    { ("url5", "url6"), 2 }
                }, 
                0,  // min 
                10, // max
                10, // limit
                
                // expected output pairs
                new Dictionary<(string, string), int>
                {
                    { ("url3", "url4"), 10 },
                    { ("url1", "url2"), 7 },
                    { ("url5", "url6"), 2 }
                }
            };

            // max, min and limit test case
            yield return new object[] { 
                // input pairs
                new Dictionary<(string, string), int>
                {
                    { ("url1", "url2"), 121 },  // x
                    { ("url3", "url4"), 7 },    // x
                    { ("url5", "url6"), 28 },   // OK
                    { ("url7", "url8"), 3 },    // x
                    { ("url9", "url10"), 55 },  // x
                    { ("url11", "url12"), 20 }, // x - because limit is 2
                    { ("url13", "url14"), 37 }, // OK
                    { ("url15", "url16"), 1 }   // x
                },  
                20, // min 
                50, // max
                2,  // limit
                
                // expected output pairs
                new Dictionary<(string, string), int>
                {
                    { ("url13", "url14"), 37 },
                    { ("url5", "url6"), 28 }
                }
            };
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void SortAndLimitTheScope_Should_Return_Only_Top_Pairs_Within_Limits(
            Dictionary<(string, string), int> pairs, 
            int? min, 
            int? max, 
            int limit, 
            Dictionary<(string, string), int> expectedPairs
        )
        {
            var result = RickAndMortyService.SortAndLimitTheScope(pairs, min, max, limit);
            
            // ToList() to force order validation
            Assert.Equal(expectedPairs.ToList(), result.ToList());
        }
    }
}
