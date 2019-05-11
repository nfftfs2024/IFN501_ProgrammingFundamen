/* This program will ask user to enter numbers of Customer to be checked,
 * and users will be asked to input information of Customers, and put into 
 * the Customer objects in the customerTrack array. At last, the array 
 * will display the Customer's account and balance one by one. */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetCustomers
{
    class TargetCustomers
    {
        static void Main(string[] args)
        {
            const double limit = 600.00;      //Declare constant for owing amount limit
            int numberOfCustomers;
            string check,
                   inputValue;  //Declare variables

            DisplayInstructions();      //Display user guidances

            Console.WriteLine("\nDo you wish to track customer status? (y/n)");
            check = Console.ReadLine();
            Console.Clear();
            if (check == "y" || check == "Y")       //Starts the program when user chooses to track customer status
            {   
                Console.WriteLine("\nHow many customers are there to be checked? (Value must be greater than 0)");      //Ask user how many customers to track
                inputValue = Console.ReadLine();
                Console.Clear();
                while (int.TryParse(inputValue, out numberOfCustomers) == false || int.Parse(inputValue) < 1)       //Show error message and request re-enter when input is not valid
                {
                    Console.WriteLine("\nInvalid data entered, please enter an interger value greater than 0.");
                    Console.WriteLine("\nHow many customers are there to be checked? (value should be greater than 0)");
                    inputValue = Console.ReadLine();
                    Console.Clear();
                }

                Customer[] customerTrack = new Customer[numberOfCustomers];     //Create Customer array with numberOfCustomers

                for (int i = 0; i < customerTrack.Length; i++)      //For each customer to be tracked
                {
                    customerTrack[i] = new Customer();      //Create Customer object
                    customerTrack[i].CustName = GetName(i);     //Get customer's name and set it through property
                    customerTrack[i].CustID = GetAccount(i);        //Get customer's account and set it through property
                    customerTrack[i].CustOweBegin = GetOweBegin(i);     //Get customer's owing amount at beginning and set it through property
                    customerTrack[i].CustTotalPurchase = GetPurchase(i);        //Get customer's purchasing amount and set it through property
                    customerTrack[i].CustTotalPayment = GetPayment(i, customerTrack[i].CustOweBegin, customerTrack[i].CustTotalPurchase);       //Get customer's payment amount and set it through property
                    Console.Clear();
                }

                DisplayResults(customerTrack, limit);      //Display all the account numbers and balances        
            }
            else
            {
                Console.WriteLine("\nSee you next time!");
                Console.ReadKey();
            }       //Show message when user does not want to check customer status
        }


        public static void DisplayInstructions()
        {
            Console.WriteLine("\nThis program will allow the user to enter the numbers of customer" +
                   "\nto check, then user has to enter Customers' name, account number, owing amount" +
                   "\nto Target at the beginning of the month, the purchasing amount, and the payment amount." +
                   "\n\nA report of the Customers' account numbers and balances of owing amount to Target" +
                   "\nwill be displayed, and account balance exceeding $600.00 will be highlighted.");
            Console.WriteLine("\n\nPRESS ANY KEY TO CONTINUEE...");
            Console.ReadKey();
            Console.Clear();
        }       //Create method of displaying user guidances

        public static string GetName(int count)
        {
            string name;
            Console.WriteLine("\nPlease enter the No.{0} customer's name. " +
                "\n(Name must be between 6 and 14 characters)", count+1);       //Ask user to enter customer name
            name = Console.ReadLine();
            while(name.Length < 6 || name.Length > 14)      
            {
                Console.WriteLine("\nThe customer name must be between 6 and 14 characters!!");
                Console.WriteLine("\nPlease enter the No.{0} customer's name", count + 1);
                name = Console.ReadLine();
                Console.Clear();
            }       //Show error message and request re-enter when the length of name is not between 6 and 14
            return name;
        }       //Create method of getting customer's name from user
        public static int GetAccount(int count)
        {
            string input;
            int account;
            Console.WriteLine("\nPlease enter the No.{0} customer's account number. " +
                "\n(Account Number must be 6 digit and starting with '4')", count + 1);     //Ask user to enter customer account number
            input = Console.ReadLine();
            while (int.TryParse(input, out account) == false || input.Length != 6 || int.Parse(input) < 400000 || int.Parse(input) > 499999)
            {
                if (int.TryParse(input, out account) == false)      //When value other than numbers is entered
                    Console.WriteLine("\nInvalid data entered - please enter a valid int value");
                else        //When input is not in 6 digits and not starting with '4'
                    Console.WriteLine("\nThe customer account number should be in 6 digits and starting with '4'");
                Console.WriteLine("\nPlease enter the {0} customer's account number", count + 1);
                input = Console.ReadLine();
                Console.Clear();
            }       //Show error message and request re-enter when the length of account number is not 6 or doen not starts with '4'
              return account;
        }       //Create method of getting customer's account from user
        public static double GetOweBegin(int count)
        {
            string input;
            double begin;
            Console.WriteLine("\nPlease enter the amount owing by the No.{0} customer to " +
               "Target at the beginning of the month" +
               "\n(Value has to be number and greater or equal to 0)", count + 1);     //Ask user to enter owing amount at the beginning
            input = Console.ReadLine();
            while (double.TryParse(input, out begin) == false || double.Parse(input) < 0)
            {
                if (double.TryParse(input, out begin) == false || double.Parse(input) < 0)       //When value other than numbers or negative number is entered
                    Console.WriteLine("\nInvalid data entered - please enter a valid positive double value");
                else         //When value entered is smaller than 0
                    Console.WriteLine("\nValue has to be greater or equal to 0");
                Console.WriteLine("\nPlease enter the amount owing to Target at the beginning of the month" +
                    "\n(Value has to be number and greater or equal to 0)");
                input = Console.ReadLine();
                Console.Clear();
            }       //Show error message and request re-enter when input is not valid
            return begin;
        }       //Create method of getting customer's owing amount at beginning from user
        public static double GetPurchase(int count)
        {
            string input;
            double purchase;
            Console.WriteLine("\nPlease enter the No.{0} customer's purchasing amount in the month", count + 1);        //Ask user to enter purchasing amount
            input = Console.ReadLine();
            while (double.TryParse(input, out purchase) == false || double.Parse(input) < 0 )
            {
                Console.WriteLine("\nInvalid data entered - please enter a valid positive double value");
                Console.WriteLine("\nPlease enter the No.{0} customer's purchasing amount in the month", count + 1);
                input = Console.ReadLine();
                Console.Clear();
            }       //Show error message and request re-enter when input is not valid
            return purchase;
        }       //Create method of getting customer's purchasing amount from user
        public static double GetPayment(int count, double oweBegin, double purchase)
        {
            string input;
            double pay;
            Console.WriteLine("\nPlease enter the No.{0} customer's payment amount in the month" +
             "\n(Overpayments by customers are not allowed)", count + 1);        //Ask user to input payment amount
            input = Console.ReadLine();
            while (double.TryParse(input, out pay) == false || double.Parse(input) < 0 || double.Parse(input) > oweBegin + purchase)
            {
                if (double.TryParse(input, out pay) == false || double.Parse(input) < 0)       //When value other than number or negative number is entered
                    Console.WriteLine("\nInvalid data entered - please enter a valid positive double value");
                else         //When overpayment is entered
                    Console.WriteLine("\nOverpayments by customers are not allowed!!");
                Console.WriteLine("\nPlease enter the No.{0} customer's payment amount in the month", count + 1);
                input = Console.ReadLine();
                Console.Clear();
            }       //Show error message and request re-enter when input is not valid
            return pay;
        }       //Create method of getting customer's payment amount at beginning from user

        public static void DisplayResults(Customer[] customerTrack, double limit)
        {
            Console.Clear();
            Console.WriteLine("\n{0,15} \t{1,20} {2,12}", "Customer Account Number","Account Balance (Owing amount to Target)","Status");      //Display headers
            Console.WriteLine("-----------------------------------------------------------------------------------------------------\n");
            foreach(Customer value in customerTrack)        //Display every customer account number and balance
            {
                string exceed = "";
                if (value.CalculateOweEnd() > limit)
                    exceed = "Credit Limit Exceeded!!";     //Identify customers owing greater than 600 to Target at the end
                Console.WriteLine("\t" + value.CustID + "\t\t\t\t\t" + value.CalculateOweEnd().ToString("C") + "\t\t\t\t" + exceed);
            }
            Console.ReadKey();
        }       //Create method of displaying the output results
    }
}
