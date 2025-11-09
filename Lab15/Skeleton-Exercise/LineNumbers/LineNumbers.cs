//namespace LineNumbers
//{
//    using System;
//    using System.IO;
//    public class Program
//    {
//        static void Main()
//        {
//            string inputFilePath = @"..\..\..\text.txt";
//            string outputFilePath = @"..\..\..\output.txt";

//            ProcessLines(inputFilePath, outputFilePath);
//        }

//        public static void ProcessLines(string inputFilePath, string outputFilePath)
//        {
//            if (!File.Exists(inputFilePath))
//            {
//                throw new FileNotFoundException("Input file not found.");
//            }
//            List<string> lines = new List<String>();
//            using (var text = File.OpenText(inputFilePath))
//            {
//                foreach(var line in File.ReadAllLines(inputFilePath))
//                {
//                    lines.Add(line);
//                }
//            }
//            Dictionary<int, KeyValuePair<int, int>> LetterSymbolCount = new Dictionary<int, KeyValuePair<int, int>>();
//            for (int i = 0; i < lines.Count; i++)
//            {
//                int letterCount = 0;
//                int symbolCount = 0;
//                foreach(var ch in lines[i])
//                {
//                    if (char.IsLetter(ch))
//                    {
//                        letterCount++;
//                    }
//                    else if (!char.IsWhiteSpace(ch))
//                    {
//                        symbolCount++;
//                    }
//                }
//                LetterSymbolCount.Add(i, new KeyValuePair<int, int>(letterCount, symbolCount));
//            }
//            for (int i = 0; i < lines.Count; i++)
//            {
//                lines[i] = $"Line {i + 1}: {lines[i]} ({LetterSymbolCount[i].Key}) ({LetterSymbolCount[i].Value})";
//            }
//        }
//    }
//}
 