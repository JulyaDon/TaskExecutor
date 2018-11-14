using System;
using System.Collections.Concurrent;
using System.Threading;

namespace TaskExecutor
{
    public class Executor
    {
        private ConcurrentQueue<Action> tasksQueue = new ConcurrentQueue<Action>();
        private Thread threadForTasks;
        CancellationTokenSource source = new CancellationTokenSource();

        public void AddExecutionQueue(Action task)
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

        private void Initialize(CancellationToken token)
        {
            threadForTasks = new Thread(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Action result;
                    bool resultOfDequeue = false;
                    resultOfDequeue = tasksQueue.TryDequeue(out result);
                    if (!resultOfDequeue)
                    {
                        Thread.Sleep(1000);
                    }
                }
            });
            threadForTasks.Start();
        }

        public void Start()
        {
            if (threadForTasks == null)
            {
                CancellationToken token = source.Token;
                Initialize(token);
            }
        }

        public void StopExecutor()
        {
            source.Cancel();
            source.Dispose();
        }
    }
}