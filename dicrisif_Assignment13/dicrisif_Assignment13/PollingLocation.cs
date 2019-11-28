/*
 * Isaiah Dicristoforo
 * dicrisif@mail.uc.edu
 * ASSIGNMENT 13
 * Multi-Threading Assignment With Word Doc Analysis
 * 
 * Professor Bill Nicholson
 * IT 3045: Contemporary Programming, Fall 2019
 * 
 * DUE: 11/28/2019
 *
 * Sources: In class work.  Our project was titled "SomeThreading"
 *
 * Description:  This program models polling locations found across the country.  In this program, a polling location contains a state represented as an enumeration,
 * a string representing the polling location's name, and and instance variable representing the total votes cast at that polling location.  Also, there is a static variable
 * that keeps track of the total votes cast across ALL polling locations. When a vote is cast, this static variable is incremented.  When we increment the static variable,
 * we need to lock that code, as more than one thread will be accessing it at the same time. This program is multi-threaded in the sense that
 * you can have multiple votes being cast at different polling locations at the same time. I tested my code with and without a lock,and the
 * results are detailed in a word document in the root directory of my project.
 */

using System;
using System.Threading;

namespace dicrisif_Assignment13
{
    public class PollingLocation
    {
        static Object myLock = new object();  //A lock to ensure only one thread can access something at a time.

        private static int unitedStatesVoteTotal; //The total votes cast across ALL polling locations.

        private States locationState;  //An enum. with all of our states.
        private string locationName; //The name of our polling location.
        private int locationVotes; //The total votes cast at this polling location. Specific to this location, unlike our grand total static variable above.

        private Thread thread; //Our thread that enables us to cast multiple votes at the same time.


        /// <summary>
        /// Constructor to set the properties of our polling place.
        /// </summary>
        /// <param name="locationState">The state of the polling place (enum)</param>
        /// <param name="locationName">The name of the polling place</param>
        public PollingLocation(States locationState, String locationName)
        {
           LocationState = locationState;
           LocationName = locationName;
           LocationVotes = 0; //Default is zero
            
        }

        /// <summary>
        /// Copy constructor to copy a polling location object.
        /// </summary>
        /// <param name="location">The polling location object to copy</param>
        public PollingLocation(PollingLocation location)
        {
            this.LocationState = location.LocationState;
            this.LocationName = location.LocationName;
            this.LocationVotes = location.LocationVotes;
        }

        /// <summary>
        /// Spawns our thread and calls the method to cast a vote the our polling location.
        /// </summary>
        public void CastVote()
        {
            thread = new Thread(Vote);
            thread.Start();
        }

        /// <summary>
        /// Casts a vote at this polling location, and increments the running static total of all votes cast across all polling locations.
        /// </summary>
        private void Vote()
        {
            //The thread has begun executing.
            Console.WriteLine("\nPerson has begun voting at " + LocationState + " at " + LocationName + "\n");

            Thread.Sleep(new Random().Next(1, 5)); //Sleep for a random amount of time.

            lock (myLock) //Locking our critical code.
            {
                UnitedStatesVoteTotal++; //Updating the static variable.  Needs to be locked.  If not, it will be corrupted by multiple threads accessing it at the same time.
            }

            LocationVotes++; //The instance variable does not need to be locked.

            //Printing our updated totals.
            Console.WriteLine("\nPerson has finished voting at " + LocationState + " at " + LocationName +
                              "\nUnitedStatesVoteTotal: " + UnitedStatesVoteTotal + " Location Total: " +
                              LocationVotes + "\n"); 
        }

        /// <summary>
        /// Waits for the current thread to finish.
        /// </summary>
        public void join()
        {
            thread.Join();
        }


        /// <summary>
        /// Property representing the total votes cast across all polling locations.
        /// </summary>
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


        /// <summary>
        /// Property representing the state the Polling Place is located.
        /// </summary>
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

        /// <summary>
        /// Property representing the name of the polling place.
        /// </summary>
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

        /// <summary>
        /// Property representing the total votes cast at this location.
        /// </summary>
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

        /// <summary>
        /// Resets the total votes cast across all polling places to zero.
        /// </summary>
        public static void Reset()
        {
            UnitedStatesVoteTotal = 0;
        }



        /// <summary>
        /// Gets a string representation of the polling place object.
        /// </summary>
        /// <returns>The string representation of the polling place object's properties.</returns>
        public override string ToString()
        {
            return "LocationState: " + LocationState + "  LocationName: " + LocationName + "\nLocationVotes:  " +
                   LocationVotes + "  Total Votes:  " + UnitedStatesVoteTotal;
        }

    } 
}
