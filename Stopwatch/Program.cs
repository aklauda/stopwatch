using System;
using System.Collections.Generic;
using System.Threading;

namespace Stoperica
{
    public class StopWatch
    {
        private DateTime _start;
        private DateTime _stop;
        private static readonly List<TimeSpan> durations = new List<TimeSpan>();

        public DateTime Start
        {
            get { return _start; }
            set { _start = value; }
        }

        public DateTime Stop
        {
            get { return _stop; }
            set { _stop = value; }
        }

        public TimeSpan Duration()
        {
            var sum_of_intervals = TimeSpan.Zero;
            var interval = _stop - _start;
            durations.Add(interval);
            foreach (var d in durations)
            {
                sum_of_intervals += d;
            }
            return sum_of_intervals;
        }

        public void Reset()
        {
            durations.Clear();
            Console.WriteLine("\nThe stopwatch has been reset");
        }

        public void Check()
        {
            if (durations.Count == 0)
            {
                Console.WriteLine("\nThe list with durations is empty");
            }
            else
            {
                foreach (var d in durations)
                {
                    Console.WriteLine(d);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new StopWatch();
            Console.WriteLine("Enter 'exit' to stop the application \nEnter'reset' to reset the stopwatch \nEnter 'check' to see the intervals");

            while (true)
            {
                Console.WriteLine("\nPress 'enter' to start");
                string start = Console.ReadLine();
                stopwatch.Start = DateTime.Now;
                if (start == "exit") break;
                else if (start == "check")
                {
                    stopwatch.Check();
                    continue;
                }
                else if (start == "reset")
                {
                    stopwatch.Reset();
                    continue;
                }
                else if (!string.IsNullOrWhiteSpace(start))
                {
                    Console.WriteLine("Invalid input: Press 'enter' to start");
                    continue;
                }

                Console.WriteLine("Press again 'enter' to stop");
                string stop = Console.ReadLine();
                stopwatch.Stop = DateTime.Now;

                Console.WriteLine("\nElapsed time: {0}", stopwatch.Duration());
            }

            Console.WriteLine("\nExiting application..");
        }
    }
}
