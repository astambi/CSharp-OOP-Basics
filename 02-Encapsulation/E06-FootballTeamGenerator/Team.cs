using System;
using System.Collections.Generic;
using System.Linq;

namespace E06_FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayerByName(string playerName)
        {
            var playerToRemove = this.players.FirstOrDefault(p => p.Name == playerName);
            if (playerToRemove == null)
            {
                throw new ArgumentException(string.Format("Player {0} is not in {1} team.", playerName, this.name));
            }

            this.players.Remove(playerToRemove);
        }

        public int GetRating()
        {
            if (this.players.Count == 0) return 0;

            double sumAvSkillLevels = this.players.Sum(p => p.Stats.Average());
            return (int)Math.Round(sumAvSkillLevels / this.players.Count);
        }
    }
}
