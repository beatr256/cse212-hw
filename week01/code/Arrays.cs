using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create a new array of doubles with the given length
        double[] result = new double[length];

        // Step 2: Loop from 0 to length-1
        for (int i = 0; i < length; i++)
        {
            // Step 3: For each index i, calculate the multiple: number * (i + 1)
            result[i] = number * (i + 1);
        }

        // Step 4: Return the filled array
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 
    /// then the list after the function runs should be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Find the index where the rotation will split the list
        // For example, if list has 9 items and amount is 3, the split index is 9 - 3 = 6
        int splitIndex = data.Count - amount;

        // Step 2: Get the last 'amount' items as a sublist
        List<int> end = data.GetRange(splitIndex, amount);

        // Step 3: Remove those last 'amount' items from the original list
        data.RemoveRange(splitIndex, amount);

        // Step 4: Insert the sublist at the beginning of the original list
        data.InsertRange(0, end);
    }
}