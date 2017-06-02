using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using WormsStats.ReplayDetails;

namespace WormsStats.Tests
{
    [TestFixture]
    public class ReplayParserTests
    {
        [Test]
        public void CanParsePlayerDetails()
        {
            var replayContents = @"
Red:     ""PlayerA""  as ""Team""
Blue:    ""Player-B"" as ""Test""
Green:   ""PlayerC""  as ""Something in ""Quotes""""
Yellow:  ""Player D"" as ""1-UP"" [Local Player] [Host]
";

            var parser = new ReplayParser();

            var replayDetails = parser.ParseString(replayContents);

            var expected = new Dictionary<string, string>();
            expected.Add("PlayerA", "Team");
            expected.Add("Player-B", "Test");
            expected.Add("PlayerC", "Something in \"Quotes\"");
            expected.Add("Player D", "1-UP");

            replayDetails.PlayerToTeamMap.ShouldBeEquivalentTo(expected);
        }

    }
}
