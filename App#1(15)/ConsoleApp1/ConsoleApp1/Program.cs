using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static readonly string path = @"D:\Lab Programming\Test\";


        static void Main(string[] args)
        {
            try
            {
                string ans = InputString("Create new file? Y/n");

                string name1 = InputString("Input File1 name");

                string name2 = InputString("Input File2 name");

                CreateNew(ans, name1);

                if (Check(name1) && Check(name2))
                {
                    List<int> file1 = ReadFile(name1);

                    if (CheckFile(file1))
                    {
                        List<int> file2 = Logic(file1);

                        WriteToFile(name2, file2);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static string InputString(string word)
        {
            Console.WriteLine(word);
            return Console.ReadLine();
        }

        static List<int> ReadFile(string name)
        {
            List<int> Nums = new List<int>();

            try
            {
                using (BinaryReader f = new BinaryReader(new FileStream(path + name, FileMode.Open, FileAccess.Read)))
                {
                    Console.WriteLine("\nIs read: ");
                    while (f.PeekChar() != -1)
                    {
                        int word = f.ReadInt32();
                        Nums.Add(word);
                        Console.Write(word + " ");
                    }
                    f.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Nums;
        }
        static int Logic(List<int> Numbers)
        {
            List<int> Ans = new List<int>();
            for (int i = 0; i < Numbers.Count; i++)
            {
                for (int j = 0; j < Numbers[i]; j++)
                {
                    Ans.Add(Numbers[i]);
                }
            }




        }

       /* static bool CheckFile(List<int> Nums)
        {
            foreach (int i in Nums)
            {
                if (i < 0 || i > 9) return false;
            }
            return true;
        }
        */
        static bool Check(string name)         // ”     *     :     <    >    ?    /    \    |
        {
            foreach (char c in name)
            {
                if (c == '"' || c == '*' || c == ':' || c == '<' || c == '>' || c == '?' || c == '/' || c == '\\' || c == '|')
                {
                    Console.WriteLine("Invalid file name");
                    return false;
                }
            }

            return true;
        }

        /*static List<int> Logic(List<int> Numbers)
        {
            List<int> Ans = new List<int>();

            for (int i = 0; i < Numbers.Count; i++)
            {
                for (int j = 0; j < Numbers[i]; j++)
                {
                    Ans.Add(Numbers[i]);
                }
            }

            return Ans;
        }*/

        static void WriteToFile(string name, List<int> Nums)
        {
            try
            {
                using (BinaryWriter f = new BinaryWriter(new FileStream(path + name, FileMode.OpenOrCreate, FileAccess.Write)))
                {
                    Console.WriteLine("\nTo write: ");
                    foreach (int i in Nums)
                    {
                        f.Write(i);
                        Console.Write(i + " ");
                    }
                    f.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void CreateNew(string ans, string name)
        {
            if (ans == "Y" || ans == "y")
            {
                WriteToFile(name, new List<int> { 2, 3, 5, 4, 6 });
            }
        }
    }
}