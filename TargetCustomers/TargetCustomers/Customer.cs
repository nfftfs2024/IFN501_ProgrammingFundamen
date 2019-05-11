/* This is the class template of the Customer. Data members of Name, ID,
 * Owing amount at beginning, Purchasing amount and Payment amount are 
 * included. A method to calculate customer's owing amount at the end
 * of the month to Target is also created. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetCustomers
{
    class Customer
    {
        private string custName;
        private int custID;
        private double custOweBegin;
        private double custTotalPurchase;
        private double custTotalPayment;     //Declare data members of Customer


        public Customer()
        {
        }   //Default Constructor

        public Customer(string name, int id)
        {
            custName = name;
            custID = id;
        }   //Constructor with Name and ID

        public Customer(string name, int id, double oweBegin, double totalPurchase, double totalPay)
        {
            custName = name;
            custID = id;
            custOweBegin = oweBegin;
            custTotalPurchase = totalPurchase;
            custTotalPayment = totalPay;
        }   //Constructor with five variables

        public string CustName
        {
            get
            {
                return custName;
            }
            set
            {
                custName = value;
            }
        }       //Property for custName
        public int CustID
        {
            get
            {
                return custID;
            }
            set
            {
                custID = value;
            }
        }       //Property for custID
        public double CustOweBegin
        {
            get
            {
                return custOweBegin;
            }
            set
            {
                custOweBegin = value;
            }
        }       //Property for custOweBegin
        public double CustTotalPurchase
        {
            get
            {
                return custTotalPurchase;
            }
            set
            {
                custTotalPurchase = value;
            }
        }       //Property for custTotalPurchase
        public double CustTotalPayment
        {
            get
            {
                return custTotalPayment;
            }
            set
            {
                custTotalPayment = value;
            }
        }       //Property for custPayment

        public double CalculateOweEnd()
        {
            double custOweEnd;
            custOweEnd = custOweBegin +custTotalPurchase - custTotalPayment;
            return custOweEnd;
        }       //Create method of calculating the owing amount to Target at the end of the month
        public override string ToString()
        {
            return "Customer Name: " + custName + "\nCustomer Account: " + custID
                + "\nOwing Amount at beginning to Target: " + custOweBegin.ToString("C") + "\nCustomer Total Purchase: "
                + custTotalPurchase.ToString("C") + "\nCustomer Total Payment: " + CustTotalPayment.ToString("C") +
                "\nOwing Amount at end of the month to Target: " + CalculateOweEnd().ToString("C");
        }       //Override the ToString method

    }
}
