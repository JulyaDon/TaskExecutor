using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskExecutorTests
{
    class CustomTestException : Exception
    {
        public CustomTestException(string message) : base(message)
        {

        }
    }
}
