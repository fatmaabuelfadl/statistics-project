using System;
using System.Linq;

namespace statistics
{
    class program
    {



        static double CalculateQuartile(double[] values, double percentile)
        {
            int index = (int)Math.Ceiling(values.Length * percentile) - 1;
            if (index < 0)
            {
                return values[0];
            }
            else if (index >= values.Length - 1)
            {
                return values[values.Length - 1];
            }
            else
            {
                double lowerValue = values[index];
                double upperValue = values[index + 1];
                double fraction = values.Length * percentile - index - 1;
                return (int)Math.Round(lowerValue * (1 - fraction) + upperValue * fraction);

            }

        }
        static double CalculateMode(double[] values)
        {
            Array.Sort(values);

            double mode = values[0];
            int count = 1;
            int maxCount = 1;

            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] == values[i - 1])
                {
                    count++;
                }
                else
                {
                    if (count > maxCount)
                    {
                        maxCount = count;
                        mode = values[i - 1];
                    }
                    count = 1;
                }
            }

            if (count > maxCount)
            {
                mode = values[values.Length - 1];
            }

            return mode;
            Console.WriteLine("the mode of the numbers is:" + CalculateMode(values));
            Console.ReadKey();
        }



        static void Main()
        {

            Console.Write("Enter the number of items: ");
            int x = int.Parse(Console.ReadLine());
            double[] values = new double[x];
            for (int i = 0; i < x; i++)
            {
                Console.Write($"Enter value {i + 1}: ");
                values[i] = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("-------------------------------------");
            Array.Sort(values);




            //Median
            double median;
            if (x % 2 != 0)
            {
                median = Math.Ceiling((double)x / 2);
                Console.WriteLine("The median= " + values[(int)median - 1]);
            }
            else
            {
                median = Math.Ceiling((double)(x + 1) / 2);
                Console.Write("The median= ");
                Console.WriteLine((values[(int)median - 1] + values[(int)median - 2]) / 2);
            }
            Console.WriteLine("-------------------------------------");

            //Range
            double max = 0;
            for (int i = 0; i < x; i++)
            {
                if (values[i] > max)
                {
                    max = values[i];
                }

            }
            Console.WriteLine("The max number= " + max);

            double min = values.Min();
            Console.WriteLine("The min number= " + min);
            double range = max - min;
            Console.WriteLine("Range= " + range);
            Console.WriteLine("-------------------------------------");

            //mode
            double mode = CalculateMode(values);
            Console.WriteLine("The mode is: " + mode);
            Console.WriteLine("-------------------------------------");

            //first quartile
            double q1 = CalculateQuartile(values, 0.25);
            Console.WriteLine($"First Quartile: {q1}");
            Console.WriteLine("-------------------------------------");
            //third quartile
            double q3 = CalculateQuartile(values, 0.75);
            Console.WriteLine($"Third Quartile: {q3}");
            Console.WriteLine("-------------------------------------");
            //The interquartile
            double IQR = q3 - q1;
            Console.WriteLine("The interquartile= " + IQR);
            Console.WriteLine("-------------------------------------");

            //Lower BoundRies
            double LowerBound = q1 - (1.5 * IQR);
            Console.WriteLine("Lower boundries= " + LowerBound);
            Console.WriteLine("-------------------------------------");

            //Upper BoundRies
            double UpperBound = q3 + (1.5 * IQR);
            Console.WriteLine("Upper boundries= " + UpperBound);
            Console.WriteLine("-------------------------------------");


            // Determine outliers

            foreach (double value in values)
            {
                Console.Write(value + " ");
                if (value < LowerBound || value > UpperBound)
                {
                    Console.WriteLine("is an outlier");
                }
                else
                {
                    Console.WriteLine("is not an outlier");
                }
            }
        }
    }

}