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
using System.Collections.Generic;
using System.Threading;


namespace dicrisif_Assignment13
{
    /// <summary>
    /// Class that tests our multi-threading PollingLocation objects.  
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Note: I have some other tests located in my unit test project as well.

            PreformSimpleTestCase(); //We only attack our static variable a few times. Results without the lock were still inaccurate.

          Console.WriteLine("\nPress Enter For Advanced Test Test Case....");

          if(Console.ReadKey().Key == ConsoleKey.Enter) //If the user presses enter, we preform the more rigorous test case.
          {
              PreformLargeTestCase(); //We hammer the static variable ten-thousand times.
          }
        }

        /// <summary>
        /// Larger test case which casts 10000 votes across 10000 polling locations.
        /// </summary>
        public static void PreformLargeTestCase()
        {
            PollingLocation.Reset(); //Resets our static variable back to zero.

            //List to store the 10,000 different polling location objects we generate.
            List<PollingLocation> locations = new List<PollingLocation>();
            for (int i = 0; i < 10000; i++)
            {
                //Adding the 10,000 polling locations to the list.
                locations.Add(new PollingLocation(States.Ohio, "Clermont County Library"));
            }

            //Spawning 1 thread in each of our 10000 location objects.
            foreach (var location in locations)
            {
                location.CastVote();
            }

            //Join each of our 10,000 threads.
            foreach (var location in locations)
            {
                location.join();
            }

            Console.WriteLine("<<<<<All Voting/Threads Completed   Total Votes Across All Locations:  "
                              + PollingLocation.UnitedStatesVoteTotal + ">>>>>");

        }


        /// <summary>
        /// Test method to spawn threads on our PollingLocation object.
        /// </summary>
        public static void PreformSimpleTestCase()
        {
            PollingLocation.Reset();  //Sets our static variable back to zero.

            //We create two different PollingLocation objects to spawn threads from
            PollingLocation location = new PollingLocation(States.California, "Whole Foods");
            PollingLocation location2 = new PollingLocation(States.Ohio, "Clermont Country Library");

            //Casting 7 votes across the two different polling locations.
            location2.CastVote();
            location.CastVote();
            location2.CastVote();
            Thread.Sleep(200); //Sleep our main thread to change things up.
            location.CastVote();
            location.CastVote();
            location2.CastVote();
            location.CastVote();

            location.join(); //Joining our threads
            location2.join();
            Thread.Sleep(200); //Sleep our main thread to change things up.

            //Display the value of our static variable.
            Console.WriteLine("<<<<<All Voting/Threads Completed   Total Votes Across All Locations:  " 
                              + PollingLocation.UnitedStatesVoteTotal + ">>>>>");
        }

    


     
    }
}

