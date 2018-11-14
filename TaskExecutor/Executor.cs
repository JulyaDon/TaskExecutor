using System;
using System.Collections.Concurrent;
using System.Threading;

namespace TaskExecutor
{
    public class Executor
    {
        private ConcurrentQueue<Action> tasksQueue = new ConcurrentQueue<Action>();
        private Thread threadForTasks;
        private  CancellationTokenSource cancellationSource = new CancellationTokenSource();

        public void AddToExecutionQueue(Action task)
        {
            tasksQueue.Enqueue(task);
        }

        private void Initialize(CancellationToken token)
        {
            threadForTasks = new Thread(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Action result;
                    if (tasksQueue.TryDequeue(out result))
                    {
                        result();
                    }
                    else
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
                Initialize(cancellationSource.Token);
            }
        }

        public void StopExecutor()
        {
            cancellationSource.Cancel();
            cancellationSource.Dispose();
        }
    }
}