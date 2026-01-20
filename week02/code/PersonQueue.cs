namespace Week02.Code
{
    public class Person
    {
        public string Name { get; set; }
        public int Turns { get; set; }

        public Person(string name, int turns)
        {
            Name = name;
            Turns = turns;
        }

        public override string ToString()
        {
            return Turns <= 0 ? $"{Name} (Infinite)" : $"{Name} ({Turns})";
        }
    }
}