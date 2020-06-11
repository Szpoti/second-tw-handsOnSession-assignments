using System;
using System.Threading;

namespace SingleInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            Mutex mutex = null;
            const string name = "RUNMEONLYONCE";
            while (true)
            {
                try
                {
                    Console.WriteLine("Checking for mutex with name:" + name);
                    mutex = Mutex.OpenExisting(name);
                    mutex.Close();
                    Console.WriteLine("Exiting...");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                catch (WaitHandleCannotBeOpenedException e)
                {
                    mutex = new Mutex(false, name);
                    Console.WriteLine("Initialize mutex local variable");
                }
            }
        }
    }
}
