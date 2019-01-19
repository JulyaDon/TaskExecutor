using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;

namespace TaskExecutor
{
    public class Executor
    {
        private readonly ConcurrentQueue<Action> _tasksQueue = new ConcurrentQueue<Action>();
        
        /// <summary>
        /// Provides number of tasks in the queue.
        /// </summary>
        public int NumberOfTasks
        {
            get { return _tasksQueue.Count(); }
        }

        /// <summary>
        /// Adds task into the queue to be executed.
        /// </summary>
        /// <param name="task">Task to execute</param>
        public void AddToExecutionQueue(Action task)
        {
            _tasksQueue.Enqueue(task);
        }

        /// <summary>
        /// Starts the thread in which execution of task happens..
        /// </summary>
        /// <param name="token"></param>
        public void Execute()
        {
            ThreadPool.QueueUserWorkItem(state => {
                while (true) { 
                    Action taskToExecute;
                    if (_tasksQueue.TryDequeue(out taskToExecute))
                    {
                        try
                        {
                            taskToExecute();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception {0} occured.", ex.Message);
                        }
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                }
            });
        }                   
    }
}