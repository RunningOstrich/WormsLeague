using System.Collections.Generic;
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

            var turns = new List<Turn>();
            var currentTurn = new Turn();

            foreach (var line in lines)
            {
                var teamSetupRegex = new Regex(@"(?<colour>[^ ]+):\s+""(?<player>([^""]*)+)""\s+as\s+""(?<team>([^\(])+)""(\s\[Local Player])*(\s\[Host])*$");

                if (teamSetupRegex.IsMatch(line))
                {
                    var args = teamSetupRegex.Match(line);

                    var playerName = args.Groups["player"].ToString();
                    var teamName = args.Groups["team"].ToString();

                    players.Add(playerName, teamName);
                }

                var turnStartRegex = new Regex(@"•••\s(?<team>([^\(])+)\s\((?<player>([^\(])+)\) starts turn$");

                if (turnStartRegex.IsMatch(line))
                {
                    var args = turnStartRegex.Match(line);

                    currentTurn = new Turn();

                    currentTurn.Player = args.Groups["player"].ToString();
                    currentTurn.Team = args.Groups["team"].ToString();
                }

                var turnWeaponRegex = new Regex(@"•••\s(?<team>([^\(])+)\s\((?<player>([^\(])+)\) fires (?<weapon>([^\(]+))");

                if (turnWeaponRegex.IsMatch(line))
                {
                    var args = turnWeaponRegex.Match(line);

                    currentTurn.WeaponUsed = args.Groups["weapon"].ToString();
                }

                var turnEndRegex = new Regex(@"•••\s(?<team>([^\(])+)\s\((?<player>([^\(])+)\) ends turn");

                if (turnEndRegex.IsMatch(line))
                {
                    var args = turnEndRegex.Match(line);

                    turns.Add(currentTurn);
                }


            }

            return new Replay(players, turns);
        }
    }
}
