using System.Collections.Generic;

public class Translator
{
    private Dictionary<string, string> translations =
        new Dictionary<string, string>();

    public void AddWord(string fromWord, string toWord)
    {
        translations[fromWord] = toWord;
    }

    public string Translate(string word)
    {
        if (translations.ContainsKey(word))
        {
            return translations[word];
        }

        return "???";
    }
}
