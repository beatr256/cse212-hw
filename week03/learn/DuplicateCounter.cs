using System.Collections.Generic;

public class DuplicateCounter
{
    public static int CountDuplicates<T>(IEnumerable<T> items)
    {
        var seen = new HashSet<T>();
        int duplicates = 0;

        foreach (var item in items)
        {
            // Add returns false if the item already exists
            if (!seen.Add(item))
            {
                duplicates++;
            }
        }

        return duplicates;
    }
}
