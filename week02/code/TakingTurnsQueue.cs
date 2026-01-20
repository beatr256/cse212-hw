using System;
using System.Collections.Generic;

namespace Week02.Code
{
    public class TakingTurnsQueue
    {
        private readonly Queue<Person> _queue = new();

        public int Length => _queue.Count;

        public void AddPerson(string name, int turns)
        {
            var person = new Person(name, turns);
            _queue.Enqueue(person);
        }

        public Person GetNextPerson()
        {
            if (_queue.Count == 0)
                throw new InvalidOperationException("No one in the queue.");

            Person person = _queue.Dequeue();

            // If turns are 0 or less, it's infinite, so always add back
            if (person.Turns <= 0)
            {
                _queue.Enqueue(person);
            }
            // If they have more than 1 turn, decrement and add back
            else if (person.Turns > 1)
            {
                person.Turns -= 1;
                _queue.Enqueue(person);
            }
            // If they had exactly 1 turn, they are not added back

            return person;
        }
    }
}