using System;
using System.IO;
using System.Collections;

namespace myApp
{
    //class untuk sorting data nama terakhir
    //class for sorting last name data
    class Person : IComparable
    {
        string full_name;
        string last_name;

        public Person(string full_name, string last_name)
        {
            this.full_name = full_name;
            this.last_name = last_name;
        }

        public int CompareTo(object obj)
        {
            Person other = (Person)obj;

            if (String.Compare(last_name, other.last_name) < 0)
                return -1;

            return 1;
        }

        public override string ToString()
        {
            return full_name;
        }        
    }
    class Program
    {
        static void Main(string[] args)
        {
            //mencari panjang baris pada file.txt
            //looking for length line in file.txt
            var lineCount = 0;
            using (var reader = File.OpenText(@".\unsorted-names-list.txt"))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }
            Person[] person_temp = new Person[lineCount];

            try
            {
                StreamReader sr = new StreamReader(@".\unsorted-names-list.txt");

                int count = 0;

                while (!sr.EndOfStream)
                {
                    string data = sr.ReadLine();
                    string full_name_temp = "";
                    string last_name_temp = "";
                    Console.WriteLine();
                    string[] info = data.Split(' ');
                    if (info.Length == 2)
                    {
                        full_name_temp = data;
                        last_name_temp = info[1];
                    }
                    else if (info.Length == 1)
                    {
                        full_name_temp = data;
                        last_name_temp = info[0];
                    }
                    else if (info.Length >= 3)
                    {
                        full_name_temp = data;
                        last_name_temp = info[2];
                    }
                    person_temp[count] = new Person(full_name_temp, last_name_temp);

                    count++;
                }
                Array.Sort(person_temp);
                sr.Close();
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            File.Delete(@".\unsorted-names-list.txt");
            StreamWriter sw = new StreamWriter(@".\sorted-names-list.txt");

            Console.WriteLine();
            foreach (Person p in person_temp)
            {
                Console.WriteLine(p);
                sw.WriteLine(p);
            }
            sw.Close();
        }
    }
}
