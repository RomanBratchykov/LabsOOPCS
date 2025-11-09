namespace LineNumbers
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public static class LineNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Enter num of task 1-6, 0 to exit");
            int num = int.Parse(Console.ReadLine());
            switch (num)
            {
                case 0:
                    return;
                case 1:
                    {
                        var inputFilePath = @"..\..\..\text.txt";
                        Console.WriteLine(ProcessLinesTask1(inputFilePath));
                    }
                    break;
                case 2:
                    {
                        string inputFilePath = @"..\..\..\text.txt";
                        string outputFilePath = @"..\..\..\output.txt";
                        ProcessLinesTask2(inputFilePath, outputFilePath);
                        foreach (var line in File.ReadAllLines(outputFilePath))
                        {
                            Console.WriteLine(line);
                        }
                    }
                    break;
                case 3:
                    {
                        string textFilePath = @"..\..\..\text.txt";
                        string wordsFilePath = @"..\..\..\words.txt";
                        CountWords(textFilePath, wordsFilePath);
                    }
                    break;
                case 4:
                    {
                        string inputFilePath = @"..\..\..\copyMe.png";
                        string outputFilePath = @"..\..\..\copyMe-copy.png";

                        CopyFile(inputFilePath, outputFilePath);
                    }
                    break;
                case 5:
                    {
                    }
                    break;
                case 6:
                    {
                        var directory = @"..\..\CopyBinaryFile";
                        var output = @"..\..\..\..";
                        ZipCreate(directory, output);
                    }
                    break;
            }
        }


        public static string ProcessLinesTask1(string inputFilePath)
        {
            int lineNumber = 1;
            string result = string.Empty;
            foreach (var line in File.ReadAllLines(inputFilePath))
            {
                if (lineNumber % 2 == 0)
                {
                    result += line;
                }
                lineNumber++;
            }
            return result;
        }
        public static void ProcessLinesTask2(string inputFilePath, string outputFilePath)
        {
            if (!File.Exists(inputFilePath))
            {
                throw new FileNotFoundException("Input file not found.");
            }
            List<string> lines = new List<String>();
            using (var text = File.OpenText(inputFilePath))
            {
                foreach (var line in File.ReadAllLines(inputFilePath))
                {
                    lines.Add(line);
                }
            }
            Dictionary<int, KeyValuePair<int, int>> LetterSymbolCount = new Dictionary<int, KeyValuePair<int, int>>();
            for (int i = 0; i < lines.Count; i++)
            {
                int letterCount = 0;
                int symbolCount = 0;
                foreach (var ch in lines[i])
                {
                    if (char.IsLetter(ch))
                    {
                        letterCount++;
                    }
                    else if (!char.IsWhiteSpace(ch))
                    {
                        symbolCount++;
                    }
                }
                LetterSymbolCount.Add(i, new KeyValuePair<int, int>(letterCount, symbolCount));
            }
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i] = $"Line {i + 1}: {lines[i]} ({LetterSymbolCount[i].Key}) ({LetterSymbolCount[i].Value})";
            }
            foreach (var line in lines)
            {
                File.AppendAllText(outputFilePath, line + Environment.NewLine);
            }
        }

        public static void CountWords(string textFilePath, string wordsFilePath)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (var line in File.ReadAllLines(wordsFilePath))
            {
                wordCount.Add(line, 0);
            }
            string allText = File.ReadAllText(textFilePath);
            string[] textWords = allText.Split(new char[] { ' ', '\n', '\r', ',', '.', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in textWords)
            {
                if (wordCount.ContainsKey(word.ToLower()))
                {
                    if (!wordCount.ContainsKey(word.ToLower()))
                    {
                        wordCount[word.ToLower()] = 0;
                    }
                    wordCount[word.ToLower()]++;
                }
            }
            var actual = (@"..\\..\\..\\actualResult.txt");
            var expected = @"..\\..\\..\\expectedResult.txt";
            if (File.Exists(actual))
            {
                File.Delete(actual);
            }
            if (File.Exists(expected))
            {
                File.Delete(expected);
            }
            foreach (var word in wordCount)
            {
                File.AppendAllText(actual, word.Key + " - " + word.Value + '\n');
            }

            Dictionary<string, int> sorted = wordCount.OrderByDescending(x => x.Value).ToDictionary();
            foreach (var word in sorted)
            {
                File.AppendAllText(expected, word.Key + " - " + word.Value + '\n');
            }
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            int bufferSize = 4096;
            using (var binaryFile = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            using (var destinationFile =new FileStream(outputFilePath, FileMode.Create, FileAccess.ReadWrite))
            {
                byte[] buffer = new byte[bufferSize];
                int bytesRead;

                while ((bytesRead = binaryFile.Read(buffer, 0, buffer.Length)) > 0)
                {
                    destinationFile.Write(buffer, 0, bytesRead);
                }

            } 
            
        }
        public static void ZipCreate(string input, string destinationPath)
        {
           ZipFile.CreateFromDirectory(input, destinationPath);
        }
    }
}