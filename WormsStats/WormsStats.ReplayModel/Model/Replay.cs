using System;
using System.Collections.Generic;
using System.Linq;

namespace WormsStats.ReplayDetails.Model
{
    public class Replay
    {
        public Dictionary<string, string> PlayerToTeamMap { get; }
        public IEnumerable<Turn> Turns { get; }

        public Replay(Dictionary<string, string> playerToTeamMap, IEnumerable<Turn> turns)
        {
            PlayerToTeamMap = playerToTeamMap;
            Turns = turns;
        }

        public IEnumerable<TotalDamage> GetTotalDamage()
        {
            var damage = new List<TotalDamage>();

            foreach (var fromPlayer in PlayerToTeamMap.Keys)
            {
                foreach (var toPlayer in PlayerToTeamMap.Keys)
                {
                    damage.Add(new TotalDamage(fromPlayer, toPlayer, Turns.Where(x => x.Player == fromPlayer).Sum(x => x.DamageCaused.To(toPlayer))));
                }
            }

            return damage;
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
            return results.ContainsKey(playerName) ? results[playerName] : 0;
        }

        public void SetDamage(string player, int damage)
        {
            results.Add(player, damage);
        }
    }

    public class TotalDamage
    {
        public TotalDamage(string fromPlayer, string toPlayer, int total)
        {
            this.fromPlayer = fromPlayer;
            this.toPlayer = toPlayer;
            this.total = total;
        }

        public string fromPlayer { get; }
        public string toPlayer { get; }
        public int total { get; }

    }
}
