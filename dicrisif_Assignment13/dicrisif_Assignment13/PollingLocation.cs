using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dicrisif_Assignment13
{
    class PollingLocation
    {
        private static int unitedStatesVoteTotal;

        private States locationState;
        private string locationName;
        private int locationVotes;

        private Thread thread;


        public PollingLocation(States locationState, String locationName)
        {
           LocationState = locationState;
           LocationName = locationName;
           LocationVotes = 0;
            
        }

        public PollingLocation(PollingLocation location)
        {
            this.LocationState = location.LocationState;
            this.LocationName = location.LocationName;
            this.LocationVotes = location.LocationVotes;
        }

        public void CastVote()
        {
            thread = new Thread(Vote);
            thread.Start();
        }

        private void Vote()
        {
          //  Console.WriteLine("\nVoting has begun in " + LocationState + " at " + LocationName + "\n");

            UnitedStatesVoteTotal++;
            LocationVotes++;

           // Console.WriteLine("\nVoting has completed in " + LocationState + " at " + LocationName + "\nUnitedStatesVoteTotal: " + UnitedStatesVoteTotal + " Location Total: " + LocationVotes + "\n");


        }

        public void join()
        {
            thread.Join();
        }


        public static int UnitedStatesVoteTotal
        {
            get
            {
                return unitedStatesVoteTotal;
            }
            private set
            {
                unitedStatesVoteTotal = value;
            }

        }


        public States LocationState
        {
            get
            {
                return locationState;
            }
            private set
            {
                this.locationState = value;
            }
        }

        public String LocationName
        {
            get
            {
                return locationName;
            }
            private set
            {
                locationName = value;
            }
        }

        public int LocationVotes
        {
            get
            {
                return locationVotes;
            }
            set
            {
                locationVotes = value; 
            }
        }    




        public override string ToString()
        {
            return base.ToString();
        }

    }
}
