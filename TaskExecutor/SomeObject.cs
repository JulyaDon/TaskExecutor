using System;
using System.Threading;

namespace TaskExecutor
{
    public class SomeObject
    {
        private readonly int _taskId;
        public SomeObject(int taskID)
        {
            _taskId = taskID;
        }

        public void ToExecute()
        {
            Console.WriteLine("Execution of task {0}", _taskId);
            if (_taskId == 24)
            {
                throw new Exception("Task id is 24");
            }
            Thread.Sleep(1000);
            Console.WriteLine("Task {0} was finished", _taskId);
        }
    }
}