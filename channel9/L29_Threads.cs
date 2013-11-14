using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace L29_SimpleThreads
{
    // create a class Alpha with a method Beta
    internal class Alpha
    {
        public void Beta()
        {
            while (true)
                Console.WriteLine("Alpha.Beta is running in its own thread.");
        }

    }
    internal class SimpleThreadApp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Thread Start/Stop/Join example\n");

            Alpha oAlpha = new Alpha();

            // Create the thread object, passing in the Alpha.Beta method via
            // the ThreadStart delegate. This does NOT start the thread.
            // ThreadStart represents the method that executes on a Thread.
            // Remember that a delegate takes a method as a parameter; a Thread,
            // on the other hand, takes a ThreadStart delegate as a parameter

            Thread oThread = new Thread(new ThreadStart(oAlpha.Beta));
            
            // start the thread
            oThread.Start();

            // spin about, waiting for the thread to become active.
            while (!oThread.IsAlive) ;

            // put the main thread to sleep for 2 milliseconds while oThread
            // does some work
            // The main thread is accessible through the keyword Thread
            Thread.Sleep(2);

            // request that oThread be stopped
            oThread.Abort();

            // Wait until oThread finishes, using Join. Join also has overloads
            // that take a millisecond or a TimeSpan object. Join blocks the
            // calling thread (here, Main) until the called thread (here,
            // oThread) terminates.
            oThread.Join();

            Console.WriteLine();
            Console.WriteLine("Alpha.Beta has finished");

            try
            {
                Console.WriteLine("Try to restart the Alpha.Beta thread");
                oThread.Start();
            }
            catch (ThreadStateException e)
            {
                Console.WriteLine("ThreadStateException trying to restart Alpha.Beta");
                Console.WriteLine("Expected, since aborted threads cannot be restarted");
                Console.WriteLine(e.Message);
            }



            Console.ReadLine();
        }
    }
}
