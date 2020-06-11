using System;
using System.Threading;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Thread firstThread = new Thread(Counting);
            Thread secondThread = new Thread(Counting);
            Console.WriteLine("First started");
            firstThread.Start();
            Console.WriteLine("First join");
            firstThread.Join();
            Thread.Sleep(3000);
            Console.WriteLine("First ended");
            Console.WriteLine("Second started");
            secondThread.Start();
            Console.WriteLine("Second join");
            secondThread.Join();
            Console.WriteLine("Second ended");
        }

        private static void Counting()
        {
            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine("Current Thread: " + Thread.CurrentThread.ManagedThreadId + ", Value of i: " + i);
                Thread.Sleep(500);
            }
        }
    }
}
