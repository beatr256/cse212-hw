using System.Text.Json;

public static class SetsAndMaps
{
    // -------------------- Problem 1 --------------------
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var results = new List<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1])
                continue;

            string reversed = $"{word[1]}{word[0]}";

            if (seen.Contains(reversed))
                results.Add($"{reversed} & {word}");
            else
                seen.Add(word);
        }

        return results.ToArray();
    }

    // -------------------- Problem 2 --------------------
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            string degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    // -------------------- Problem 3 --------------------
    public static bool IsAnagram(string word1, string word2)
    {
        string a = word1.Replace(" ", "").ToLower();
        string b = word2.Replace(" ", "").ToLower();

        if (a.Length != b.Length)
            return false;

        var counts = new Dictionary<char, int>();

        foreach (char c in a)
        {
            if (counts.ContainsKey(c))
                counts[c]++;
            else
                counts[c] = 1;
        }

        foreach (char c in b)
        {
            if (!counts.ContainsKey(c))
                return false;

            counts[c]--;

            if (counts[c] < 0)
                return false;
        }

        return true;
    }

    // -------------------- Problem 5 --------------------
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        using var responseStream = client.Send(request).Content.ReadAsStream();
        using var reader = new StreamReader(responseStream);

        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var results = new List<string>();

        foreach (var feature in featureCollection.features)
        {
            results.Add($"{feature.properties.place} - Mag {feature.properties.mag}");
        }

        return results.ToArray();
    }
}
