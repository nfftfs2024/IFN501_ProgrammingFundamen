/*LenHypo.cs
 * This application allows users to input
 * length of two sides of three different
 * triangles.
 * It outputs the length of hypotenuse 
 * of each triangle along with their sides. 
 */
using System;

namespace LengthHypotenuse
{
    class LengthHypotenuse
    {
        static void Main(string[] args)
        {
            double sideA1,
                   sideA2,
                   hypoA,
                   sideB1,
                   sideB2,
                   hypoB,
                   sideC1,
                   sideC2,
                   hypoC;      //Declare sides and hypotenuses of the three triangles                             

            DisplayInstructions();      //Display initial instructions
           
            GetSideValues("1", out sideA1, out sideA2);     //get two sides of the first triangle
            GetSideValues("2", out sideB1, out sideB2);     //get two sides of the second triangle
            GetSideValues("3", out sideC1, out sideC2);     //get two sides of the third triangle

            hypoA = CalculateHypotenuse(sideA1, sideA2);    //Calculate the length of the first triangle
            hypoB = CalculateHypotenuse(sideB1, sideB2);    //Calculate the length of the second triangle
            hypoC = CalculateHypotenuse(sideC1, sideC2);    //Calculate the length of the third triangle

            DisplayResults(sideA1, sideA2, hypoA, sideB1, sideB2, hypoB, sideC1, sideC2, hypoC);    //Display the lengths of two sides and hypotenuses of three triangles
            Console.ReadKey();
        }

        public static void DisplayInstructions()        //Declare DisplayInstructions method
        {
            Console.WriteLine("How long is the hypotenuse?");
            Console.WriteLine("Hypotenuses in three different will be calculated");
            Console.WriteLine("from the other two sides of the triangles.");
            Console.WriteLine("You will be asked to input the length(CM) of ");
            Console.WriteLine("Side 1 and Side 2 for three different");
            Console.WriteLine("triangles one by one.");
            Console.WriteLine("Hypotenuse will be calculated from these inputs.");
            Console.WriteLine();
            Console.WriteLine("PRESS ANY KEY TO START...");     //Display messages to be shown before the inputs
            Console.ReadKey();
        }

        public static void GetSideValues(string triangleNO, out double side1, out double side2)     //Decare GetSideValues method
        {
            string inputValue1,
                   inputValue2;
            Console.Clear();
            Console.WriteLine("What is the length(CM) for side 1 of triangle {0}?", triangleNO);
            inputValue1 = Console.ReadLine();
            side1 = double.Parse(inputValue1);      //Get the length of the first side and transform into double data type
            Console.WriteLine("What is the length(CM) for side 2 of triangle {0}?", triangleNO);
            inputValue2 = Console.ReadLine();
            side2 = double.Parse(inputValue2);      //Get the length of the second side and transform into double data type
        }

        public static double CalculateHypotenuse(double side1, double side2)        //Declare CalculateHypotenuse method
        {
            return Math.Sqrt((side1*side1)+(side2*side2));      //Calculate the hypotenuse by the two sides
        }       

        public static void DisplayResults(double sideA1, double sideA2, double hypoA,
                                          double sideB1, double sideB2, double hypoB,
                                          double sideC1, double sideC2, double hypoC)       //Declare DisplayResults method
        {
            Console.Clear();
            Console.WriteLine("{0,35}","Calculation of the Hypotenuses");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(" {0}\n    side 1:{1,9:f1} CM\n    side 2:{2,9:f1} CM\n    hypotenuse:{3,6:f2} CM", "Triangle 1", sideA1, sideA2, hypoA);     //Print the length of three sides of the first triangle
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(" {0}\n    side 1:{1,9:f1} CM\n    side 2:{2,9:f1} CM\n    hypotenuse:{3,6:f2} CM", "Triangle 2", sideB1, sideB2, hypoB);     //Print the length of three sides of the second triangle
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(" {0}\n    side 1:{1,9:f1} CM\n    side 2:{2,9:f1} CM\n    hypotenuse:{3,6:f2} CM", "Triangle 3", sideC1, sideC2, hypoC);     //Print the length of three sides of the third triangle
            Console.WriteLine("--------------------------------------------");
        }
    }
}
