using System.Collections.Generic;

namespace E05_MordorsCrueltyPlan
{
    public class Gandalf
    {
        private int happinessPoints;

        public Gandalf()
        {
            this.happinessPoints = 0;
        }

        public int HappinessPoints => this.happinessPoints;

        public void EatFood(string food)
        {
            var foodHapinessPoints = new Dictionary<string, int>();
            foodHapinessPoints["cram"] = 2;
            foodHapinessPoints["lembas"] = 3;
            foodHapinessPoints["apple"] = 1;
            foodHapinessPoints["melon"] = 1;
            foodHapinessPoints["honeycake"] = 5;
            foodHapinessPoints["mushrooms"] = -10;

            if (foodHapinessPoints.ContainsKey(food))
            {
                this.happinessPoints += foodHapinessPoints[food];
            }
            else
            {
                this.happinessPoints--;
            }
        }

        public string CalculateMood()
        {
            if (this.happinessPoints > 15) return "JavaScript";
            if (this.happinessPoints >= 1) return "Happy";
            if (this.happinessPoints >= -5) return "Sad";
            return "Angry";
        }
    }
}
