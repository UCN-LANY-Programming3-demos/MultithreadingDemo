using System;

namespace MultithreadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskDemo demo = new();

            //demo.RunningSimpleTask();
            //demo.ReturningValue();
            demo.RunningMultipleTasks();

            Console.ReadLine();
        }
    }
}
