using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static readonly string[] StopWords = { "the", "and", "to", "a", "of", "in", "on", "is", "was", "more", "than", "he", "she", "you", "are", "said", "am",
            "at", "that", "as", "but", "with", "out", "for", "up", "one", "from", "into", "had", "been", "so", "much", "his", "her", "no", "not", "only","ago", "i", "it",
        "were", "be", "they", "would", "have", "time", "where", "arms", "do", "what", "all", "him", "could", "how", "who", "will", "my", "lannister", "stark", "lannister's",
        "me", "your", "them", "this", "if", "after", "go", "has", "herself", "say", "did", "why", "we"};
        public static readonly string[] EndSentenceSigns = { ".", "!", "?", ";", ":", "(", ")" };

        public static bool CheckForStopWords(string word)
        {
            foreach (var stopWord in StopWords)
                if (stopWord.Equals(word))
                    return true;
            return false;
        }
        public static List<List<string>> ParseSentences(string text)
        {
            List<List<string>> resultText = new List<List<string>>();
            text = text.ToLower();
            for (int i = -1; i < text.Length;) {
                List<string> sentence = new List<string>();
                StringBuilder word = new StringBuilder();
                while (++i < text.Length && !EndSentenceSigns.Any(text[i].ToString().Contains))
                {
                    if (!char.IsLetter(text[i]) && !text[i].Equals('\'') && word.Length > 0)
                    {
                        if (!CheckForStopWords(word.ToString()) && 
							!EndSentenceSigns.Any(text[i - 1].ToString().Contains))
                            sentence.Add(word.ToString());
                        word = new StringBuilder();
                        continue;
                    }
                    if (char.IsLetter(text[i]) || text[i].Equals('\''))
                        word.Append(text[i].ToString());
                }
                if (!CheckForStopWords(word.ToString()) && word.Length > 0)
                    sentence.Add(word.ToString());
                resultText.Add(sentence);
            }
            return resultText;
        }
    }
}