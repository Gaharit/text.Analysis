using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
	internal static class TrigramGeneratorTask
	{
		/*
		Повторите ту идею с Биграммами, только используя триграммную модель текста.
		Теперь вам передается словарь, в котором ключем являются два первых слова триграмм текста (разделенные пробелом),
		а значение — третье слово триграммы.
		Продолжите фразу до длины phraseWordsCount слов так, чтобы каждое следующее 
		слово определялось двумя предыдущими по переданному словарю.
		*/
		public static string ContinuePhraseWithTrigramms(Dictionary<string, string> mostFrequentNextWords, string wordPair, int phraseWordsCount)
		{
            StringBuilder phrase = new StringBuilder();
            phrase.Append(wordPair);
            for (int i = 2; i < phraseWordsCount; i++)
            {
                if (!mostFrequentNextWords.ContainsKey(wordPair))
                    break;
                wordPair = (wordPair.Remove(0, wordPair.IndexOf(' ') + 1) + " "  + mostFrequentNextWords[wordPair]);
                if (!mostFrequentNextWords.ContainsKey(wordPair))
                    break;
                phrase.Append(" " + mostFrequentNextWords[wordPair]);
            }
            return phrase.ToString();
		}
	}
}
