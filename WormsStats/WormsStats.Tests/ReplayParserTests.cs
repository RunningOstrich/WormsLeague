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
Red:     ""MarkJ""        as ""FullmetalWormage""
Blue:    ""PeterGerrard"" as ""The Necronomicon""
Green:   ""samblackburn"" as ""Famous ""Quotes""""
Yellow:  ""davideadie""   as ""1-UP"" [Local Player] [Host]
Magenta: ""Ninja-Ferret"" as ""Suicide Squad""
Cyan:    ""michaelupton"" as ""Scoobies""
";

            var parser = new ReplayParser();

            var replayDetails = parser.ParseString(replayContents);

            var expected = new Dictionary<string, string>();
            expected.Add("MarkJ", "FullmetalWormage");

            replayDetails.PlayerToTeamMap.ShouldBeEquivalentTo(expected);
        }

    }
}
