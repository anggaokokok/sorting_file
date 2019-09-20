using System;
using System.IO;
using System.Collections;

namespace myApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {   // Open the text file using a stream reader.
                // using (StreamReader sr = new StreamReader(@"C:\Users\IT-YUSUF\Desktop\coba.txt"))
                // {
                //     // Read the stream to a string, and write the string to the console.
                //     //String line = sr.ReadToEnd();
                //     //Console.WriteLine(line);
                //     int counter = 0;
				// 	string ln;
					  
				// 	while ((ln = sr.ReadLine()) != null)
				// 	{
				// 		Console.WriteLine(ln);
				// 		counter++;
				// 	}
				// 	sr.Close();
				// 	Console.WriteLine($"File has {counter} lines.");
                // }
                string[] lines = File.ReadAllLines(@"C:\Users\IT-YUSUF\Desktop\coba.txt");
                char[] spearator = {' '};
                foreach (string line in lines)
                {
                    String[] strlist = line.Split(spearator,  StringSplitOptions.RemoveEmptyEntries);
                    Console.WriteLine(strlist.Length);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
