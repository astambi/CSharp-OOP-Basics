using System;

namespace E05_MordorsCrueltyPlan
{
    public class StartUp
    {
        public static void Main()
        {
            var gandalf = FeedGandalf();
            Console.WriteLine(gandalf.HappinessPoints);
            Console.WriteLine(gandalf.CalculateMood());
        }

        private static Gandalf FeedGandalf()
        {
            var foods = Console.ReadLine()
                        .ToLower()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var gandalf = new Gandalf();
            foreach (var food in foods)
            {
                gandalf.EatFood(food);
            }
            return gandalf;
        }
    }
}
