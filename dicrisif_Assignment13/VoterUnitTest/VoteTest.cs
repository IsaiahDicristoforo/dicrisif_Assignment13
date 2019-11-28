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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using dicrisif_Assignment13;

namespace VoterUnitTest
{
    /// <summary>
    /// Models a class to preform unit tests on my multi-threaded PollingLocation objects.
    /// </summary>
    [TestClass]
    public class VoteTest
    {
        /// <summary>
        /// Testing two PollingLocation objects and casting 7 votes.
        /// </summary>
        [TestMethod]
        public void Test1()
        {
            PollingLocation.Reset(); //Resets our static variable to zero.
            PollingLocation location = new PollingLocation(States.Idaho,"Idaho Public Library");
            PollingLocation location2 = new PollingLocation(States.NewYork, "Times Square");

            location.CastVote(); //7 votes cast in total at the two different locations.
            location.CastVote();
            location2.CastVote();
            location.CastVote();
            location2.CastVote();
            location.CastVote();
            location2.CastVote();

            location.join(); //Join the two threads.
            location2.join();

            //We should have a total of seven votes cast.
            Assert.AreEqual(7, PollingLocation.UnitedStatesVoteTotal );
        }

        /// <summary>
        /// Unit test method that casts 90000 votes across 3 polling locations.
        /// </summary>
        [TestMethod]
        public void Test2()
        {
            PollingLocation.Reset();//Resets our static variable back to zero.

            //Create three different polling locations.  If we create any more they should be stored in a list or array.
            PollingLocation location1 = new PollingLocation(States.NewHampshire, "Burger King");
            PollingLocation location2 = new PollingLocation(States.Alaska, "An Igloo");
            PollingLocation location3 = new PollingLocation(States.Maryland, "Maryland Town Hall");

            for (int i = 0; i < 10000; i++) //Note: we are not casting 10,000 votes.
            {
                //Casting 9 votes each iteration through the loop.  Expected total:  90000 votes cast. 

                location1.CastVote();
                location3.CastVote();
                location3.CastVote();
                location2.CastVote();
                location3.CastVote();
                location1.CastVote();
                location3.CastVote();
                location1.CastVote();
                location3.CastVote();
            }

            location1.join(); //The join method is really called in the PollingLocation class.
            location2.join();
            location3.join();
            
            //We should have 90000 votes cast across all three polling locations.  If not, our static variable has been corrupted.
            Assert.AreEqual(90000, PollingLocation.UnitedStatesVoteTotal, "Test Failed... Actual:" + PollingLocation.UnitedStatesVoteTotal );
                


        }
    }
}
