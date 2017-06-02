using System.Collections.Generic;

namespace WormsStats.ReplayDetails.Model
{
    public class Replay
    {
        public Dictionary<string, string> PlayerToTeamMap { get; }
        public IEnumerable<Turn> Turns { get; set; }

        public Replay(Dictionary<string, string> playerToTeamMap, IEnumerable<Turn> turns)
        {
            PlayerToTeamMap = playerToTeamMap;
            Turns = turns;
        }
    }

    public class Turn
    {
        public string Player { get; set; }
        public string Team { get; set; }
        public string WeaponUsed { get; set; }
    }
}
