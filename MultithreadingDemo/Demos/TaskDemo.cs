using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingDemo
{
    class TaskDemo
    {
        public void RunningSimpleTask()
        {
            Task task = new Task(() =>
            {
                Console.WriteLine("Task on thread {0} started.",
                Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(3000);
                Console.WriteLine("Task on thread {0} finished.",
                Thread.CurrentThread.ManagedThreadId);
            });

            task.Start();
            Console.WriteLine("This is the main thread.");

            
        }

        public void ReturningValue()
        {
            Task<int> task = new Task<int>(() =>
            {
                Thread.Sleep(3000);
                return 2 + 3;
            });

            task.Start();
            Console.WriteLine("This is the main thread.");
            int sum = task.Result;
            Console.WriteLine("The result from the task is {0}.", sum);
        }

        public void RunningMultipleTasks()
        {
            Task<int> task = new Task<int>(() =>
            {
                Console.WriteLine("Task on thread {0} started.", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(3000);
                Console.WriteLine("Task on thread {0} finished.", Thread.CurrentThread.ManagedThreadId);

                return 2 + 3;
            });

            Task<string> task2 = task.ContinueWith<string>(taskInfo =>
            {
                Console.WriteLine("The result from the task is {0}.", taskInfo.Result);
                Console.WriteLine("Task2 on thread {0} started.", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(3000);
                Console.WriteLine("Task2 on thread {0} finished.", Thread.CurrentThread.ManagedThreadId);

                return "Miguel";
            });

            task2.ContinueWith(taskInfo =>
            {
                Console.WriteLine("The result from the second task is {0}.", taskInfo.Result);
            });

            task.Start();

            Console.WriteLine("This is the main thread.");

        }
    }
}
