using NUnit.Framework;
using TaskExecutor;
using System;

namespace TaskExecutorTests
{
    [TestFixture]
    class ExecutorTest
    {
        [Test]
        public void ShouldAddToExecutionQueue()
        {
            Executor executor = new Executor();
            Action task = () => Console.WriteLine("Task");
            executor.AddToExecutionQueue(task);
            int expectedResult = executor.NumberOfTasks;
            Assert.That(expectedResult, Is.EqualTo(1));
        }
    }
}
