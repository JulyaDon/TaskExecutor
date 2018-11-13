using System;
using System.Collections.Concurrent;

namespace TaskExecutor
{
    public class Executor
    {
        private ConcurrentQueue<Action> tasksQueue = new ConcurrentQueue<Action>(); 
        public void AddTask(Action task)
        {
            task = new ClientTask().Task;
            tasksQueue.Enqueue(task);
        }
        public void ExeculeAllTasks()
        {
            foreach(Action task in tasksQueue)
            {
                task();
            }
        }
    }
}