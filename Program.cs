using System.Diagnostics;
using System;
using System.Globalization;
using System.IO;


namespace FileApp
{
    internal class Program
    {

        static void WriteToFile(string pathName)
        {

            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(pathName);
                //Write a line of text
                sw.WriteLine("Hello World!!");
                //Write a second line of text
                sw.WriteLine("From the StreamWriter class");
                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }

        static void ReadFromFile(string pathName)
        {

            double sum = 0;
            string? line;
            int step = 0;

            try
            {
                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ".";
                provider.NumberGroupSeparator = ",";

                // Create a StreamReader
                using (StreamReader reader = new StreamReader(pathName))
                {

                    // Read line by line
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        double doubleVal = Convert.ToDouble(line, provider);
                        sum += doubleVal;
                        step++;
                    }


                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            Console.WriteLine("suma: {0}", sum);
            Console.WriteLine("ile: {0}", step);
            Console.ReadKey();

        }


        private static List<double> ResultList(string pathName)
        {

            List<double> result = new List<double>();
            string line;

            try
            {
                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ".";
                provider.NumberGroupSeparator = ",";

                // Create a StreamReader
                using (StreamReader reader = new StreamReader(pathName))
                {

                    // Read line by line
                    while ((line = reader.ReadLine()) != null)
                    {
                        double doubleVal = Convert.ToDouble(line, provider);
                        result.Add(doubleVal);
                    }

                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

            return result;
        }


        private static void ShowList(List<double> lista)
        {
            foreach (double val in lista)
            {
                Console.WriteLine(val);
            }
        }

        static bool Sprawdz(double elem)
        {
            if (elem < 0.5) return true;
            else return false;
        }


        static void Main(string[] args)
        {

            string pathName = @"C:\Users\MW\source\repos\FileApp\zadanie.txt";

            //ReadFromFile(pathName);
            //WriteToFile(pathName);   

            List<double> res = ResultList(pathName);
            //ShowList(res);

            List<double> filtered = res.FindAll(e => e > 0.5);

            //ShowList(filtered);

            List<double> filtered1 = res.Where(e => e > 0.5).ToList();

            ShowList(filtered1);

            double filteredAvg = res.Where(e => e > 0.5).Average();

            Console.WriteLine("średnia: {0}", filteredAvg);


            Stopwatch stoper = new Stopwatch();
            stoper.Start();

            ShowList(filtered1);
            Thread.Sleep(1000);
            stoper.Stop();

            TimeSpan ts = stoper.Elapsed;


            Console.WriteLine(ts);
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine("RunTime " + elapsedTime);


        }
    }
}

