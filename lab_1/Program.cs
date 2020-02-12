using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir_address = @"D:\trash\3 lvl\6\comp_sys\lab_1\";
            //string[] file_name = new string[] { "encode_64.txt", "encode_65.txt", "encode_66.txt" }; 
            string[] file_name = new string[] { "text_1.txt.bz2", "text_2.txt.bz2", "text_3.txt.bz2" }; 2
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //alphabet fro Ukrainian, Digits and Symbols, which are used in texts
            //char[] alphabet = new char[84] {'А', 'Б', 'В', 'Г', 'Ґ', 'Д', 'Е', 'Є', 'Ж', 'З', 'И', 'І', 'Ї', 'Й',
            //        'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
            //        'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ю', 'Я',
            //    'а', 'б', 'в', 'г', 'ґ', 'д', 'е', 'є', 'ж', 'з', 'и', 'і', 'ї', 'й',
            //        'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
            //        'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ю', 'я',
            //    ',',' ','(', ')', '.', ':', '-','"',
            //    '0','1','2','3','4','5','6','7','8','9'
            //};

            //alphabet for Base64
            char[] alphabet = new char[64]
               {  'A','B','C','D','E','F','G','H','I','J','K','L','M',
            'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            'a','b','c','d','e','f','g','h','i','j','k','l','m',
            'n','o','p','q','r','s','t','u','v','w','x','y','z',
            '0','1','2','3','4','5','6','7','8','9','+','/'};

            for (int f = 0; f < file_name.Length; f++)
            {
                try
                {
                    double[] numberOfOccurence = new double[alphabet.Length];
                    double frequency = 0;
                    double entropy = 0;
                    int amount_of_letters = 0;

                    string file_address = dir_address + file_name[f];
                    FileInfo file = new FileInfo(file_address);
                    Console.WriteLine("Файл для аналізу: " + file.Name);
                    using (StreamReader sr = new StreamReader(file_address))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            for (int i = 0; i < alphabet.Length; i++)
                            {
                                var count = line.Count(x => x == alphabet[i]);
                                numberOfOccurence[i] += count;
                            }
                            amount_of_letters += line.Count();
                        }
                    }
                    Console.WriteLine("Загальна кількість символів файлу: " + amount_of_letters);
                    Console.WriteLine();
                    for (int i = 0; i < alphabet.Length; i++)
                    {
                        frequency = numberOfOccurence[i] / amount_of_letters;
                        Console.WriteLine("Відносна частота появи літери \"" + alphabet[i] + "\" у тексті = " + frequency +
                            " ; Літера присутня у тексті: " + numberOfOccurence[i] + " разів.");
                        if (frequency != 0)
                        {
                            entropy += -(frequency * Math.Log(frequency, 2));
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("Середня ентропія алфавіту для данного тексту: " + entropy);
                    Console.WriteLine("Кількість інформації у тексті: " + (entropy * amount_of_letters) / 8);
                    if ((entropy * amount_of_letters) / 8 > amount_of_letters)
                    {
                        Console.WriteLine("");
                    }
                    else if ((entropy * amount_of_letters) / 8 < amount_of_letters)
                    {
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("Кількість інформації у тексті така ж, як і розмір файлу: ");
                    }
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
