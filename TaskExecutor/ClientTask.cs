using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TaskExecutor
{
    public class ClientTask
    {
        public void Task()
        {
            Random random = new Random();
            int randomDelay = random.Next(1000, 10000);
            System.Threading.Thread.Sleep(randomDelay);
            Console.WriteLine("Task was executed.");
        }
    }
}