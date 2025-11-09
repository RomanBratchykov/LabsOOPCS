//namespace EvenLines
//{
//    using System;
//    using System.IO;
//    public class EvenLines
//    {
//        static void Main()
//        {
//            string inputFilePath = @"..\..\..\text.txt";

//            Console.WriteLine(ProcessLines(inputFilePath));
//        }

//        public static string ProcessLines(string inputFilePath)
//        {
//            var stringReader = new StreamReader(inputFilePath);
//            int lineNumber = 1;
//            string result = string.Empty;
//            foreach (var line in stringReader.ReadLine())
//            {
//                if(lineNumber % 2 == 0)
//                {
//                    result += line + Environment.NewLine;
//                }
//            }
//            return result;
//        }
//    }
//}
