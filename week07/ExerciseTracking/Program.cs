using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    // Base class
    public abstract class Activity
    {
        private DateTime _date;
        private int _minutes;

        public Activity(DateTime date, int minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        protected DateTime Date => _date;
        protected int Minutes => _minutes;

        public abstract double GetDistance(); // km
        public abstract double GetSpeed();    // km/h
        public abstract double GetPace();     // min/km

        public virtual string GetSummary()
        {
            return $"{Date:yyyy-MM-dd} {GetType().Name} ({Minutes} min): Distance {GetDistance():F2} km, Speed {GetSpeed():F2} kph, Pace {GetPace():F2} min/km";
        }
    }

    // Swimming class
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            return _laps * 50 / 1000.0; // meters to km
        }

        public override double GetSpeed()
        {
            return (GetDistance() / Minutes) * 60;
        }

        public override double GetPace()
        {
            return Minutes / GetDistance();
        }
    }

    // Cycling class
    public class Cycling : Activity
    {
        private double _distance;

        public Cycling(DateTime date, int minutes, double distance) : base(date, minutes)
        {
            _distance = distance;
        }

        public override double GetDistance()
        {
            return _distance;
        }

        public override double GetSpeed()
        {
            return (_distance / Minutes) * 60;
        }

        public override double GetPace()
        {
            return Minutes / _distance;
        }
    }

    // Running class
    public class Running : Activity
    {
        private double _distance;

        public Running(DateTime date, int minutes, double distance) : base(date, minutes)
        {
            _distance = distance;
        }

        public override double GetDistance()
        {
            return _distance;
        }

        public override double GetSpeed()
        {
            return (_distance / Minutes) * 60;
        }

        public override double GetPace()
        {
            return Minutes / _distance;
        }
    }

    // Program
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise Tracking Summary:");

            // Create activity instances
            Activity swim = new Swimming(new DateTime(2024, 4, 1), 30, 20);
            Activity bike = new Cycling(new DateTime(2024, 4, 2), 60, 15.5);
            Activity run = new Running(new DateTime(2024, 4, 3), 45, 6.2);

            // Add to list
            List<Activity> activities = new List<Activity> { swim, bike, run };

            // Display summaries
            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
