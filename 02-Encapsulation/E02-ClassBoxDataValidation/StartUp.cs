using System;
using System.Linq;
using System.Reflection;

namespace E02_ClassBoxDataValidation
{
    public class StartUp
    {
        public static void Main()
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            try
            {
                var boxDimensions = new double[3];
                for (int i = 0; i < boxDimensions.Length; i++)
                {
                    boxDimensions[i] = double.Parse(Console.ReadLine());
                }
                var box = new Box(boxDimensions[0], boxDimensions[1], boxDimensions[2]);

                Console.WriteLine($"Surface Area - {box.GetSurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.GetLateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {box.GetVolume():f2}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }
        }
    }
}
