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
                var regex = new Regex(@"(?<colour>[^ ]+):\s+""(?<player>([^""]*)+)""\s+as\s+""(?<team>(.*)+)""(\s\[Local Player])*(\s\[Host])*$");

                if (regex.IsMatch(line))
                {
                    var args = regex.Match(line);

                    var playerName = args.Groups["player"].ToString();
                    var teamName = args.Groups["team"].ToString();

                    players.Add(playerName, teamName);
                }
            }

            return new Replay(players);
        }
    }
}
