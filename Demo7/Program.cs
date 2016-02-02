using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo7
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = null;
            double d;
            int i;
            {
                // kysytään käyttäjältä rivi
                StreamWriter outputFile = new StreamWriter("integer.txt");
                StreamWriter outputFile2 = new StreamWriter("double.txt");
                do
                {

                    Console.WriteLine("Give a number (enter stops):");
                    number = Console.ReadLine();


                    bool parsed = int.TryParse(number, out i);
                    if (!parsed)
                    {
                        double.TryParse(number, out d);
                        outputFile2.WriteLine(d); // kirjoitetaan levylle
                    }
                    else
                    {
                        outputFile.WriteLine(i);



                    }

                } while (number.Length != 0);



                // suljetaan tiedosto
                outputFile.Close();
                outputFile2.Close();

                try
                {
                    using (StreamReader sr = new StreamReader("integer.txt"))
                    using (StreamReader sr1 = new StreamReader("double.txt"))
                    {
                        // read the stream to a string, and write the string to console
                        String line2 = sr.ReadToEnd();
                        String line3 = sr1.ReadToEnd();
                        Console.WriteLine(line2);
                        Console.WriteLine(line3);

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("There werw some problems writing or reading the file:");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
