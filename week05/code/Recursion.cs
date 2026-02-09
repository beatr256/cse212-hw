using System.Collections;

public static class Recursion
{
    // #################
    // # Problem 1
    // #################
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return n * n + SumSquaresRecursive(n - 1);
    }

    // #################
    // # Problem 2
    // #################
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            char c = letters[i];

            if (!word.Contains(c))
            {
                PermutationsChoose(results, letters, size, word + c);
            }
        }
    }

    // #################
    // # Problem 3
    // #################
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (remember.ContainsKey(s))
            return remember[s];

        decimal result;

        if (s == 0)
            result = 0;
        else if (s == 1)
            result = 1;
        else if (s == 2)
            result = 2;
        else if (s == 3)
            result = 4;
        else
            result =
                CountWaysToClimb(s - 1, remember) +
                CountWaysToClimb(s - 2, remember) +
                CountWaysToClimb(s - 3, remember);

        remember[s] = result;
        return result;
    }

    // #################
    // # Problem 4
    // #################
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        string withZero = pattern.Substring(0, index) + "0" + pattern.Substring(index + 1);
        string withOne = pattern.Substring(0, index) + "1" + pattern.Substring(index + 1);

        WildcardBinary(withZero, results);
        WildcardBinary(withOne, results);
    }

    // #################
    // # Problem 5
    // #################
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        int[,] directions =
        {
            {1, 0},   // right
            {0, 1},   // down
            {-1, 0},  // left
            {0, -1}   // up
        };

        for (int i = 0; i < 4; i++)
        {
            int newX = x + directions[i, 0];
            int newY = y + directions[i, 1];

            if (maze.IsValidMove(currPath, newX, newY))
            {
                SolveMaze(results, maze, newX, newY, currPath);
            }
        }

        currPath.RemoveAt(currPath.Count - 1);
    }
}
