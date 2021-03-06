﻿using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;

// Thread pooling is a form of multithreading where tasks are created queued
// automatically until a thread is available to run them.
// The program below first creates a ManualResetObject, allowing the program
// to know when the thread pool has finished creating all the items. Next, it
// attempts to add the threads to the threadpool.

namespace L29_ThreadPools
{
    // useful way to store info that can be passed as a state on a work item
    public class State
    {
        public int Cookie;
        public State(int iCookie)
        {
            Cookie = iCookie;
        }
    }


    public class Alpha
    {
        public Hashtable HashCount;
        public ManualResetEvent eventX;
        public static int iCount = 0;
        // maximum number of threads in the pool
        public static int iMaxCount = 0;

        public Alpha(int maxCount)
        {
            HashCount = new Hashtable(maxCount);
            iMaxCount = maxCount;
        }

        // Beta is the method that'll be called when the work item is being
        // serviced by a thread in the thread pool, i.e. this method will be
        // called when the thread pool has an available thread.
        public void Beta(Object state)
        {
            // Write out the hashcode and cookie for the current thread
            Console.WriteLine("HashCode and cookie for current thread: {0} {1}", 
                Thread.CurrentThread.GetHashCode(), ((State)state).Cookie);

            Console.WriteLine("HashCount.Count == {0}, Thread.CurrentThread.GetHashCode == {1}",
                HashCount.Count, Thread.CurrentThread.GetHashCode());

            // lock the HashCount hashtable, to allow thread-safe access to it
            lock (HashCount)
            {
                // Add the current thread's hashcode to the hashtable, if it
                // doesn't yet exist
                if (!HashCount.ContainsKey(Thread.CurrentThread.GetHashCode()))
                    HashCount.Add(Thread.CurrentThread.GetHashCode(), 0);

                // increment the number of times this thread has been accessed
                HashCount[Thread.CurrentThread.GetHashCode()] =
                    ((int)HashCount[Thread.CurrentThread.GetHashCode()]) + 1;

            }

            // Do some busy work, because why not
            int sleepyTime = 2000;
            Thread.Sleep(sleepyTime);

            // Interlocked.Increment and Interlocked.Decrement are thread-safe
            // variable modification methods
            Interlocked.Increment(ref iCount);
            if (iCount == iMaxCount)
            {
                Console.WriteLine("\nSetting eventX");
                // ManualResetEvent Set() method sets the state of the event to
                // be signalled, allowing waiting threads to be notified
                eventX.Set();
            }

        }


    }


    public class SimplePool
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Thread pool sample:");
            bool W2K = false;
            // allow a total of 10 threads in the pool
            int MaxCount = 10;
            // mark the event as unsignalled
            ManualResetEvent eventX = new ManualResetEvent(false);
            Console.WriteLine("Queueing {0} items to Thread Pool", MaxCount);
            // create the work items
            Alpha oAplha = new Alpha(MaxCount);
            // make sure the work items have a reference to the signalling event
            oAplha.eventX = eventX;
            Console.WriteLine("Queue to Thread Pool 0");

            try
            {
                // queue the work items, which has the added effect of checking
                //  which os is running. The QueueUserWorkItem method queues a 
                // methods for execution, and specifies an object containing data
                // to be used by the method.
                ThreadPool.QueueUserWorkItem(new WaitCallback(oAplha.Beta), new State(0));
                W2K = true;
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine("These APIs may fail when called on a non-Windows 2000 system");
                Console.WriteLine(e);
            }
            if (W2K)    // if running on an OS that supports the ThreadPool API
            {
                for (int iItem = 0; iItem < MaxCount; iItem++)
                {
                    // queue the work items
                    Console.WriteLine("Queue to Thread Pool {0}", iItem);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(oAplha.Beta), new State(0));
                }
                Console.WriteLine("Waiting for Thread Pool to drain");
                // the eventX.WaitOne() method sets the event to wait until
                // eventX.Set() occurs. The Set() call is done in Alpha.Beta
                // Wait until the event is fired, meaning eventX.Set() has been
                // signalled.
                eventX.WaitOne(Timeout.Infinite, true);
                // the WaitOne won't return until the event has been signalled
                Console.WriteLine("Thread Pool has been drained (Event Fired)");
                Console.WriteLine();
                Console.WriteLine("Load across threads:");
                foreach (object item in oAplha.HashCount.Keys)
                {
                    Console.WriteLine("{0} - {1}", item, oAplha.HashCount[item]);
                }

            }


            Console.ReadLine();
        }
    }
}
