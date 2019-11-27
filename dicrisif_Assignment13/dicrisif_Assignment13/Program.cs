using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicrisif_Assignment13
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            PollingLocation location1 = new PollingLocation(States.Maine, "Maine Community Church");
            location1.CastVote();

            PollingLocation location2 = new PollingLocation(States.Ohio, "Clermont Country Library");
            location2.CastVote();
         

            PollingLocation location3 = new PollingLocation(States.California, "Go Green Smoothie Wearhouse");
            location3.CastVote();
            */

            List<PollingLocation> locations = new List<PollingLocation>();
            for (int i = 0; i < 1000; i++)
            {
                locations.Add(new PollingLocation(States.California, "A random place"));

            }
            for (int i = 0; i < locations.Count; i++)
            {
                locations[i].CastVote();

            }

            for (int i = 0; i < locations.Count; i++)
            {
                locations[i].join();

            }





            Console.WriteLine("Test: " + PollingLocation.UnitedStatesVoteTotal);

        }
    }
}
