using System;

namespace E03_Mankind
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                var studentInfo = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var workerInfo = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var student = new Student(studentInfo[0], studentInfo[1], studentInfo[2]);
                var worker = new Worker(workerInfo[0], 
                                        workerInfo[1],
                                        decimal.Parse(workerInfo[2]), 
                                        decimal.Parse(workerInfo[3]));

                Console.WriteLine(student.ToString());
                Console.WriteLine(worker.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
