using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using FluentAssertions;
using NUnit.Framework;
using WormsStats.ReplayDetails;
using WormsStats.ReplayDetails.Model;

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

        [Test]
        public void CanParseSimpleTurn()
        {
            var replayContents = @"
[00:00:00.00] ••• 1-Up (Player D) starts turn
[00:00:11.12] ••• 1-Up (Player D) fires Bazooka
[00:00:15.72] ••• 1-Up (Player D) ends turn; time used: 6.12 sec turn, 3.00 sec retreat
[00:00:23.36] ••• Damage dealt: 43 (1 kill) to Test (Player-B), 14 to Team (PlayerA), 56 to Something in ""Quotes"" (PlayerC)
";

            var parser = new ReplayParser();

            var replayDetails = parser.ParseString(replayContents);

            var expected = new Turn();
            expected.Player = "Player D";
            expected.Team = "1-Up";
            expected.WeaponUsed = "Bazooka";

            var turnDetails = replayDetails.Turns.First();

            replayDetails.Turns.Count().Should().Be(1);

            turnDetails.Player.Should().Be(expected.Player);
            turnDetails.Team.Should().Be(expected.Team);

            turnDetails.WeaponUsed.Should().Be(expected.WeaponUsed);
            turnDetails.DamageCaused.To("Player-B").Should().Be(43);
            turnDetails.DamageCaused.To("PlayerA").Should().Be(14);
            turnDetails.DamageCaused.To("PlayerC").Should().Be(56);


        }
    }
}
