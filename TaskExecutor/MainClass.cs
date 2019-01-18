using System;
using System.Threading;

namespace TaskExecutor
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            Executor executor = new Executor();

            //We start executor. It starts checking its execution queue and execute task if present
            Console.WriteLine("Main Thread - Starting executor");

            //Create threads, which will be adding tasks for execution
            for (int i = 0; i < 15; i++)
            {
                Thread threadForTasks = new Thread(() =>
                {
                    Action toExecute = new SomeObject(Thread.CurrentThread.ManagedThreadId).ToExecute;
                    executor.AddToExecutionQueue(toExecute);
                });
                Console.WriteLine("Task with ID {0} was added", threadForTasks.ManagedThreadId);
                threadForTasks.Start();
            }

            executor.Execute();

            Console.Read();
        }
        
    }
}
