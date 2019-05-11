using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MinDistance
{    class MinDistance
    {
        static void Main(string[] args)
        {
            int minDist,    // Create variable for Minimum Distance
                counter = 0, // Create variable for counting Basic Operation
                length; // Create variable for Size of Dataset
            double millitime = 0;   // Create variable for Execution Time

            Stopwatch timer = new Stopwatch();  // Create timer object to record Execution Time
            Random rand = new Random(); // Create random number object to generate random Dataset
            int[] basicOperation1 = new int[31];    // Create array for Basic Operations of MinDistance1
            int[] basicOperation2 = new int[31];    // Create array for Basic Operations of MinDistance2
            double[] bestTime1 = new double[31]; // Create array for Best Case Time of MinDistance1
            double[] worstTime1 = new double[31];    // Create array for Worst Case Time of MinDistance1
            double[] averageTime1 = new double[31];  // Create array for Average Exection Time of MinDistance1
            double[] totalTime1 = new double[31];    // Create array for calculating Average Execution Eime of MinDistance1
            double[] bestTime2 = new double[31]; // Create array for Best Case Time of MinDistance2
            double[] worstTime2 = new double[31];    // Create array for Worst Case Time of MinDistance2
            double[] averageTime2 = new double[31];  // Create array for Average Execution Time of MinDistance2
            double[] totalTime2 = new double[31];    // Create array for calculating Average Execution Time of MinDistance2

            int calRound = 0;   // Create variable for Calculation Rounds
            while (calRound < 10)   // Loop for running 10 times to calculate the Average Execution Time
            {
                int time = 0;   // Create variable for every calculating Times
                length = 0; // Set Size of Dataset to 0 at the beginning of every round

                while (length < 30001)  // When array Size is less than 30001
                {
                    int[] array = new int[length];  // Create an array of numbers
                    //int[] array = {100, 781, 354, 5, 100, 12345678, 100, 3, 1000000, 3211}; // Test dataset 1 
                    //int[] array = { 0, 123456, 77777, 8888, 3148, 10, 2147483641, 717171717, 50000, 320, 777, 456951, 739182, 214781354, 6437510 };   // Test dataset 2
                    //length = array.Length;    // Test dataset length
                    for (int index = 0; index < length; index++)    // Fill the array with random numbers
                    {
                        array[index] = rand.Next(0, 200);  // Generate random numbers between 0 and max value
                    }

                    //--------------------------------------------------------------------------------------
                    //  Calculating Minimum Distance for Algorithm MinDistance1
                    //--------------------------------------------------------------------------------------

                    timer.Restart();    // Start recording Execution Time
                    minDist = GetMinDistance1(array, ref counter);  // Call GetMinDistance1 method
                    timer.Stop();   // Stop recording Execution Time
                    basicOperation1[time] = counter;    // Store Basic Operation result into array for this calculating Times
                    millitime = timer.Elapsed.TotalMilliseconds;    //  Get Execution Time from timer parameters

                    Console.WriteLine("MinDistance1 - Rounds:{0},\tSize:{1},\tElapsed:{2}", calRound, time * 1000, timer.Elapsed);    // Display program progress
                    CompareTime(calRound, time, millitime, ref bestTime1, ref worstTime1, ref totalTime1);  // Call CompareTime method

                    //Console.WriteLine("\n\n\tMinDistance1");
                    //Console.WriteLine("\n\tInput size:  \t\t{0}", length);  // Display input size for functional test
                    //Console.Write("\tArray elements:\t\t");   // Display input size for functional test
                    //foreach (int value in array)
                    //    Console.Write("{0},", value);
                    //Console.WriteLine("\n\tBasic operation:  \t{0}", counter);    // Display input size for functional test
                    //Console.WriteLine("\tThe minimum distance:  \t{0}", minDist); // Display input size for functional test
                    //Console.WriteLine("\tExecution time:  \t{0}\n", timer.Elapsed);    // Display input size for functional test

                    counter = 0;    // Clear counter for Basic Operation

                    //--------------------------------------------------------------------------------------
                    //  Calculating Minimum Distance for Algorithm MinDistance2
                    //--------------------------------------------------------------------------------------

                    timer.Restart();    // Start recording Execution Time
                    minDist = GetMinDistance2(array, ref counter);  // Call GetMinDistance2 method
                    timer.Stop();   // Stop recording Execution Time
                    basicOperation2[time] = counter;    // Store Basic Operation result into array for this calculating Times
                    millitime = timer.Elapsed.TotalMilliseconds;    //  Get Execution Time from timer parameters

                    Console.WriteLine("MinDistance2 - Rounds:{0},\tSize:{1},\tElapsed:{2}", calRound, time * 1000, timer.Elapsed);    // Display program progress
                    CompareTime(calRound, time, millitime, ref bestTime2, ref worstTime2, ref totalTime2);  // Call CompareTime method

                    //Console.WriteLine("\tMinDistance2");
                    //Console.WriteLine("\n\tInput size:  \t\t{0}", length);  // Display input size for functional test
                    //Console.Write("\tArray elements:\t\t");   // Display input size for functional test
                    //foreach (int value in array)
                    //    Console.Write("{0},", value);
                    //Console.WriteLine("\n\tBasic operation:  \t{0}", counter);    // Display input size for functional test
                    //Console.WriteLine("\tThe minimum distance:  \t{0}", minDist); // Display input size for functional test
                    //Console.WriteLine("\tExecution time:  \t{0}\n", timer.Elapsed);    // Display input size for functional test

                    counter = 0;    // Clear counter for Basic Operation

                    //--------------------------------------------------------------------------------------

                    length += 1000; // Increment the Size of Dataset by 1000
                    time++; // Increment the calculating Times by 1
                }
                calRound++; // Increment the calculating Rounds by 1
            }

            averageTime1 = CalAverageTime(calRound, totalTime1, averageTime1);  // Calculate Average Execution Time for MinDistance1
            averageTime2 = CalAverageTime(calRound, totalTime2, averageTime2);  // Calculate Average Execution Time for MinDistance2

            Console.Clear();
            DisplayOpResult(basicOperation1, basicOperation2);  // Display results of Basic Operation for both algorithm
            DisplayEffResult(averageTime1, bestTime1, worstTime1, "MinDistance1");  // Display results of Execution Times for MinDistance1
            DisplayEffResult(averageTime2, bestTime2, worstTime2, "MinDistance2");  // Display results of Execution Times for MinDistance2
            Console.ReadKey();
        }

        public static int GetMinDistance1(int[] arr, ref int counter) // Algorithm MinDistance1
        {
            int dmin = Int32.MaxValue;    // Set dmin as maximum value
            for (int i = 0; i < arr.Length; i++)    // Outer loop of MinDistance1
                for (int j = 0; j < arr.Length; j++)    // Inner loop of MinDistance1
                {
                    if (i != j) // First IF condition
                    {
                        if (Math.Abs(arr[i] - arr[j]) < dmin)   // Second IF condition
                        {
                            dmin = Math.Abs(arr[i] - arr[j]);
                        }
                        counter++;  // Increment Basic Operation by 1
                    }
                    //Console.WriteLine("n: {3}, i:{1}, j:{2}, n^2 - i * j = {0}", Math.Pow(arr.Length, 2) - (i * j), i, j, arr.Length);   // Display variant for correctness test
                }
            //Console.WriteLine("Then j becomes 10 and i becomes 10, thus n^2 - i * j becomes 100 - 10 * 10 = 0, and the algorithm terminates!");   // Display variant for correctness test
            return dmin;    // Return minimum distance
        }

        public static int GetMinDistance2(int[] arr, ref int counter) // Algorithm MinDistance2
        {
            int dmin = Int32.MaxValue,
                temp = 0;    // Set dmin as maximum value
            for (int i = 0; i < arr.Length - 1; i++)    // Outer loop of MinDistance2
                for (int j = i + 1; j < arr.Length; j++)   // Inner loop of MinDistance2
                {
                    temp = Math.Abs(arr[i] - arr[j]);
                    if (temp < dmin)
                        dmin = temp;
                    counter++;  // Increment Basic Operation by 1
                    //Console.WriteLine("n: {3}, i:{1}, j(i+1):{2}, (n-1)*n-i*(i+1) = {0}", (arr.Length-1)*arr.Length - i*(i+1), i, j, arr.Length); // Display variant for correctness test
                }
            //Console.WriteLine("Then j becomes 10 and i becomes 9, thus (n-1)*n-i*(i+1) becomes 9 * 10 - 9 * 10 = 0, and the algorithm terminates!");  // Display variant for correctness test
            return dmin;    // Return minimum distance
        }

        public static double[] CalAverageTime(int round, double[] total, double[] average)  // Calculating Average Execution Time
        {
            for (int x = 0; x < total.Length; x++)  // Calculate for evert calculating Times
            {
                average[x] = total[x] / round;  // Average Execution Time = Total Time divided by calculating Rounds
            }
            return average; // Return average time array
        }

        public static void CompareTime(int cal, int time, double milli, ref double[] best, ref double[] worst, ref double[] total)
        {
            total[time] += milli;   // Accumulating Total Execution Time with each Execution Time
            worst[time] = Math.Max(worst[time], milli); // Compare each Execution Time and set the max time to the Worst Case Time
            if (cal < 1)    // In case the Best Case Time will always be 0
                best[time] = milli;
            else
                best[time] = Math.Min(best[time], milli);   // Compare each Execution Time and set the min time to the Best Case Time
        }

        public static void DisplayOpResult(int[] basicOp1, int[] basicOp2)  // Display result of both Basic Operation Numbers
        {
            Console.WriteLine("\n\n\n\t\t\t\t    Result of Basic Operations");  // Display result topic
            Console.WriteLine("-----------------------------------------------------------------------------------------------\n");
            Console.WriteLine("{0,15} \t{1,30} \t{2,36}", "Array Size", "MinDistance1 Basic Operation", "MinDistance2 Basic Operation");    // Diplay Headers
            Console.WriteLine("-----------------------------------------------------------------------------------------------\n");
            for (int x = 0; x < basicOp1.Length; x++)
            {
                int size = x * 1000;    // Get Size of Dataset
                Console.WriteLine("{0,13} \t{1,29} \t{2,35}", size, basicOp1[x], basicOp2[x]);  // Display Size of Dataset and the Baisc Operation Numbers
            }
            Console.WriteLine("\n\n\n\n\n");
        }

        public static void DisplayEffResult(double[] average, double[] best, double[] worst, string alg)    // Display result of Best, Average and Worst Execution Times
        {
            Console.WriteLine("\n\n\n\t\t\tResult of {0} Execution Time (in milliseconds)", alg);   // Display result topic
            Console.WriteLine("-----------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("{0,15} {1,25} {2,25} {3,25}", "Array Size", "Best Case Time", "Average Time", "Worst Case Time");    // Diplay Headers
            Console.WriteLine("-----------------------------------------------------------------------------------------------------\n");
            for (int x = 0; x < average.Length; x++)
            {
                int size = x * 1000;    // Get Size of Dataset
                Console.WriteLine("{0,13} {1,25} {2,24} {3,25}", size, best[x], average[x], worst[x]);  // Display Size of Dataset and the Execution Times
            }
        }
    }
}
