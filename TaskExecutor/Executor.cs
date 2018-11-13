using System;
using System.Collections.Concurrent;

namespace TaskExecutor
{
    public class Executor
    {
        delegate void TaskExecutorDel();
        private ConcurrentQueue<TaskExecutorDel> tasksQueue = new ConcurrentQueue<TaskExecutorDel>();
        private void Task()
        {
            Random random = new Random();
            int randomDelay = random.Next(1000, 10000);
            System.Threading.Thread.Sleep(randomDelay);
            Console.WriteLine("Execution of task");
        }
        private void AddTask()
        {
            TaskExecutorDel taskExecutorDel = Task;
            tasksQueue.Enqueue(taskExecutorDel);
        }
    }
}