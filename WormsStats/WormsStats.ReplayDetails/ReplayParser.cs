using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WormsStats.ReplayDetails.Model;

namespace WormsStats.ReplayDetails
{
    public class ReplayParser
    {
        public Replay ParseString(string replayContents)
        {
            var lines = replayContents.Split("\n\r".ToCharArray());

            var players = new Dictionary<string,string>();

            foreach (var line in lines)
            {
                var result = from Match match in Regex.Matches(line, "\"([^\"]*)\"")
                             select match.ToString();

                var playerName = result.ElementAt(0);
                var teamName = result.ElementAt(1);

                players.Add(playerName, teamName);
            }

            return new Replay(players);
        }
    }
}
