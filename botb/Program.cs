using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace botb
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = string.Empty;
            Random rnd = new Random();
            bool answerRandom = false;
            if (File.Exists("path"))
            {
                path = System.IO.File.ReadAllText(@"path");
            }
            else
            {
                path = "mind.dat";
                Console.WriteLine("Файл по указанному пути не найден");
            }
            string[] text = System.IO.File.ReadAllLines(path);
            string input;
            bool silent = false;
            do
            {
                input = Console.ReadLine();
                input = input.ToLower();
                
                if (input == "silent")
                {
                    silent = true;
                }
                else if (input == "getup")
                {
                    silent = false;
                }
                if (silent)
                {
                    continue;
                }

                if (input == "date")
                {
                    Console.WriteLine(DateTime.Now.ToString("dd MMMM yyyy"));
                }
                else if(input == "time")
                {
                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                }
                else if (input == "change")
                {
                    Console.WriteLine("Введите новый путь:");
                    using (FileStream fs = File.Create("path"))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(Console.ReadLine());
                  
                        fs.Write(info, 0, info.Length);
                    }
                    Application.Restart();
                }
                else if (input =="exit")
                {
                    Application.Exit();
                }
                else
                {
                    string newInput;
                    newInput = input.Replace("  ", string.Empty);
                    newInput = newInput.Replace(".", string.Empty);
                    newInput = newInput.Trim().Replace(" ", string.Empty);
                    
                    for (int i =0; i <= text.Length-1; i++)
                    {
                        string newStr;
                        
                        newStr = text[i].Replace("  ", string.Empty);
                        newStr = newStr.Replace(".", string.Empty);
                        
                        newStr = newStr.Trim().Replace(" ", string.Empty);
                        newStr = newStr.Trim().Replace(".", string.Empty);
                        
                        if (newStr == newInput)
                        {
                            Console.WriteLine(text[i + 1]);
                            answerRandom = false;
                            break;
                        }
                        else
                        {
                            answerRandom = true;
                        }
                    }
                    if (answerRandom)
                    {
                        Console.WriteLine(text[rnd.Next(0, text.Length - 1)]);
                        answerRandom = false;
                        
                    }
                }

            }
            while (true) ;

        }
    }
}
