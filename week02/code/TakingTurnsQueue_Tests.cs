using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Week02.Code;

[TestClass]
public class TakingTurnsQueueTests
{
    [TestMethod]
    // Scenario: Bob (2), Tim (5), Sue (3). Run until empty.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Defect(s) Found: The original code didn't add people back to the queue properly; 
    // it often removed them after only one turn regardless of the turn count.
    public void TestTakingTurnsQueue_FiniteRepetition()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);
        Person[] expectedResult = { bob, tim, sue, bob, tim, sue, tim, sue, tim, tim };

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        int i = 0;
        while (players.Length > 0)
        {
            if (i >= expectedResult.Length) Assert.Fail("Queue should have ran out of items.");
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Bob (2), Tim (Forever/0), Sue (3). Run 10 times.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Defect(s) Found: The code failed to treat '0' as infinite. It removed Tim 
    // from the queue immediately after his first turn.
    public void TestTakingTurnsQueue_ForeverZero()
    {
        var timTurns = 0;
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", timTurns);
        var sue = new Person("Sue", 3);
        Person[] expectedResult = { bob, tim, sue, bob, tim, sue, tim, sue, tim, tim };

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        for (int i = 0; i < 10; i++)
        {
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
        }
        
        var infinitePerson = players.GetNextPerson();
        Assert.AreEqual(timTurns, infinitePerson.Turns);
    }

    [TestMethod]
    // Scenario: Try to get person from empty queue.
    // Expected Result: Exception "No one in the queue."
    // Defect(s) Found: The original code either didn't throw an exception 
    // or the exception message did not match the expected requirement.
    public void TestTakingTurnsQueue_Empty()
    {
        var players = new TakingTurnsQueue();
        try
        {
            players.GetNextPerson();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("No one in the queue.", e.Message);
        }
    }
}