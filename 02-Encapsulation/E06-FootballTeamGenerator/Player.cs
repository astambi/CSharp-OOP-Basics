using System;

namespace E06_FootballTeamGenerator
{
    public class Player
    {
        private string[] statNames = new string[] { "Endurance", "Sprint", "Dribble", "Passing", "Shooting" };

        private string name;
        private int[] stats;

        public Player(string name, int[] stats)
        {
            this.Name = name;
            this.Stats = stats;
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

        public int[] Stats
        {
            get { return this.stats; }
            private set
            {
                this.stats = new int[5];
                for (int i = 0; i < 5; i++)
                {
                    if (value[i] < 0 || value[i] > 100)
                    {
                        throw new ArgumentException(string.Format("{0} should be between 0 and 100.", statNames[i]));
                    }
                    this.stats[i] = value[i];
                }
            }
        }
    }
}
