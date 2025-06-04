using DotNetInterviewProblems.Problems;
using Xunit;
using System.Linq;

namespace DotNetInterviewProblems.Tests.Problems
{
    public class GroupAnagramsTests
    {
        [Fact]
        public void Group_ReturnsCorrectGroups()
        {
            string[] words = {"eat", "tea", "tan", "ate", "nat", "bat"};
            var groups = GroupAnagrams.Group(words);
            Assert.Contains(groups, g => g.Contains("eat") && g.Contains("tea") && g.Contains("ate"));
            Assert.Contains(groups, g => g.Contains("tan") && g.Contains("nat"));
            Assert.Contains(groups, g => g.Contains("bat"));
        }
    }
}
