using System.Collections.Generic;

namespace WormsStats.ReplayDetails.Model
{
    public class Replay
    {
        public Dictionary<string, string> PlayerToTeamMap { get; }

        public Replay(Dictionary<string, string> playerToTeamMap)
        {
            PlayerToTeamMap = playerToTeamMap;
        }
    }
}
