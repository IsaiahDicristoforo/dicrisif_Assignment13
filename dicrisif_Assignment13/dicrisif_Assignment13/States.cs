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

namespace dicrisif_Assignment13
{

    /// <summary>
    /// Enumeration representing our American states.
    /// </summary>
   public enum States
    {
        Alabama,
        Alaska,
        Arizona,
        Arkansas,
        California,
        Colorado,
        Connecticut,
        Delaware,
        Florida,
        Georgia,
        Hawaii,
        Idaho,
        Illinois,
        Indiana,
        Iowa,
        Kansas,
        Kentucky,
        Louisiana,
        Maine,
        Maryland,
        Massachusetts,
        Michigan,
        Minnesota,
        Mississippi,
        Missouri,
        Montana,
        Nebraska,
        Nevada,
        NewHampshire,
        NewJersey,
        NewMexico,
        NewYork,
        NorthCarolina,
        NorthDakota,
        Ohio,
        Oklahoma,
        Oregon,
        Pennsylvania,
        RhodeIsland,
        SouthCarolina,
        SouthDakota,
        Tennessee,
        Texas,
        Utah,
        Vermont,
        Virginia,
        Washington,
        WestVirginia,
        Wisconsin,
        Wyoming,

    }
}
