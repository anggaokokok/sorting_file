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
                using (StreamReader sr = new StreamReader(@"C:\Users\IT-YUSUF\Desktop\coba.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    //String line = sr.ReadToEnd();
                    //Console.WriteLine(line);
                    int counter = 0;
					string ln;
					  
					while ((ln = sr.ReadLine()) != null)
					{
						Console.WriteLine(ln);
						counter++;
					}
					sr.Close();
					Console.WriteLine($"File has {counter} lines.");
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
