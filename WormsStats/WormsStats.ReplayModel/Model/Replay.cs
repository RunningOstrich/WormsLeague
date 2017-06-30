using System;
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
        public DamageCaused DamageCaused { get; }

        public Turn()
        {
            DamageCaused = new DamageCaused();
        }

    }
    
    public class DamageCaused
    {
        private Dictionary<string, int> results = new Dictionary<string, int>();

        public int To(string playerName)
        {
            return results[playerName];
        }

        public void SetDamage(string player, int damage)
        {
            results.Add(player, damage);
        }
    }
}
