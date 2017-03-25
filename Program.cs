using System;
using System.IO;

namespace TextAnalysis
{
    internal static class Program
    {
        public static void Main()
        {
            var text = File.ReadAllText(@"C:\Users\st.group\Downloads\GameOfThrones.txt");

           // Console.WriteLine("SentencesParserTask:");
            var sentences = SentencesParserTask.ParseSentences(text);
            var frequency = FrequencyAnalysisTask.GetMostFrequentNextWords(sentences);
            var frequencyTrigram = FrequencyAnalysisTask.GetMostFrequentNextWordsTrigram(sentences);
            // for (int i = 0; i < Math.Min(10, sentences.Count); i++)
            //     Console.WriteLine(string.Join("|", sentences[i]) + ".");
            // Console.WriteLine(); 
            // Console.WriteLine("FrequencyAnalysisTask:");

            // Console.WriteLine();
            Console.WriteLine("BigramGeneratorTask:");
            foreach (var start in new[] { "arya", "tyrion", "jon", "ned", "robert", "dany", "catelyn", "bran", "cersei", "sam", "jaime" })
            {
                var phrase = BigramGeneratorTask.ContinuePhraseWithBigramms(frequency, start, 15);
                Console.WriteLine(phrase);
            }
            Console.WriteLine();
            Console.WriteLine("TrigramGeneratorTask:");
            foreach (var start in new[] { "boiled leather"})
            {
                var phrase = TrigramGeneratorTask.ContinuePhraseWithTrigramms(frequencyTrigram, start, 40);
                Console.WriteLine(phrase);
            }
            Console.ReadLine();
        }
    }
}