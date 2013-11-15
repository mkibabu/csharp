using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

// The producer-consumer problem (aka bounded buffer problem) is an example of
// a thread synchronization problem. It consists of two parties, a producer (or
// writer) or consumer (reader) who share a common, fixed-size buffer used as a
// queue. The producer's job is to generate a piece of data, put it into the
// buffer, and start again. The consumer, on the other hand, is tasked with
// consuming/reading the data (i.e. removing it from the buffer) one piece at a
// time. The problem is to make sure the producer doesn't try to add data into
// the buffer if it's full, and the consumer won't try to remove data from the
// buffer if empty.

// The solution is to have the producer sleep if the buffer is full, and wait for
// the consumer to remove some of the data. Once the consumer removes an item
// from the buffer, it notifies the producer, who fills the buffer again.
// Similarly, the consumer sleeps if the buffer is empty, and is notified by
// the producer once it (producer) adds data to the list.

// Keywords, methods & objects used here:
// lock - keyword, a la synchronize in Java
// Monitor - act as a semaphore, syncing access by taking and releasingt he lock
// on an object.
// Monitor.Wait(object) - makes this thread release anyu lock it has on object,
// and wait to be notified next time it is available
// Monitor.Pulse(object) - notifies the waiting thread (assumes one) that the
// lock on the object has been released, and the object is now available

namespace L29_ThreadSynchronization
{
    public class Cell
    {
        public int[] CellContents { get; set; }
        public int MaxCapacity { get; set; }
        public int CurCapacity { get; set; }

        public Cell(int cap)
        {
            MaxCapacity = cap;
            CellContents = new int[MaxCapacity];
        }

        public bool CellIsFull()
        {
            return CurCapacity == MaxCapacity;
        }

        public bool CellIsEmpty()
        {
            return CurCapacity == 0;
        }

        // The Consumer. Waits until there is data to read, then reads from the
        // cell.
        public int ReadFromCell(out int consumed)
        {
            // Enter synchronization block
            lock (this)
            {
                // if there isn't any data in the cell yet, wait.
                if (CellIsEmpty())
                {
                    try
                    {
                        // Wait for the Monitor.Pulse in WriteToCell. The Monitor
                        // class provides a mechanism to sync access to objects.
                        // Wait(obj) releases the lock on an object and blocks
                        // the current thread until it reacquires the lock 
                        Console.WriteLine("Consumer found cell empty");
                        Monitor.Wait(this);
                    }
                    catch (SynchronizationLockException e)
                    {
                        Console.WriteLine(e);
                    }
                    catch (ThreadInterruptedException e)
                    {
                        Console.WriteLine(e);
                    }
                }

                // Cell is not empty, so consume the data after decreasing the
                // current capacity
                consumed = CellContents[--CurCapacity];
                Console.WriteLine("Consume: {0}", consumed);
                // let waiting threads know of a change in the locked object
                // (this)'s state.
                Monitor.Pulse(this);

            }   // Exit the synchronization block

            return consumed;
        }

        public void WriteToCell(int n)
        {
            // Enter synchronization block
            lock (this)
            {
                // If the cell is full (i.e. no consuming has been done), wait 
                // until Cell.ReadFromCell is done consuming.
                if (CellIsFull())
                {
                    try
                    {
                        Console.WriteLine("Producer found cell full");
                        Monitor.Wait(this);
                    }
                    catch (SynchronizationLockException e)
                    {
                        Console.WriteLine(e);
                    }
                    catch (ThreadInterruptedException e)
                    {
                        Console.WriteLine(e);
                    }
                }

                // Cell is not full, i.e. consuming is done. Write to cell and
                // increment current capacity
                CellContents[CurCapacity++] = n;
                Console.WriteLine("Produce: {0}", CellContents[CurCapacity - 1]);
                // Notify waiting thread(s) that the lock on this has been
                // released
                Monitor.Pulse(this);
            }
        }// Exit synchronization block
    }

    public class CellProducer
    {
        public Cell Cell {get; set; }           // Field to hold the objects produced

        public CellProducer(Cell box)
        {
            Cell = box;             // pass in cell to use
        }

        public void ThreadRun()
        {
            for (int i = 0; i < Cell.MaxCapacity; i++)
            {
                Cell.WriteToCell(i); // simulate producing
            }
        }
    }

    public class CellConsumer
    {
        Cell Cell { get; set; }

        public CellConsumer(Cell box)
        {
            Cell = box;
        }

        public void ThreadRun()
        {
            int consumed;
            for (int i = 0; i < Cell.MaxCapacity; i++)
            {
                Cell.ReadFromCell(out consumed);
            }
        }
    }

    public class MonitorSample
    {
        public static void Main()
        {
            int result = 0;
            Cell cell = new Cell(10);
            CellProducer prod = new CellProducer(cell);
            CellConsumer cons = new CellConsumer(cell);

            // create the threads
            Thread producer = new Thread(new ThreadStart(prod.ThreadRun));
            Thread consumer = new Thread(new ThreadStart(cons.ThreadRun));

            // start the threads
            try
            {
                producer.Start();
                consumer.Start();

                // join both with no timeout, and run till done
                producer.Join();
                consumer.Join();

            }
            catch(ThreadStartException e)
            {
                Console.WriteLine(e);
                result = 1;
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e);
                result = 1;
            }


            Console.ReadLine();

            Environment.ExitCode = result;
        }
    }
}
