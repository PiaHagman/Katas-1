using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderSystem
{
    class OnlineOrder
    {
        private int orderNumber;
        public DateTime orderDate;
        public string productName;
        public double orderSum;

        private static int nextOrderNumber = 1000;


        public OnlineOrder(string givenProductName, double givenOrderSum)
        {
            orderNumber = nextOrderNumber;
            nextOrderNumber++;

            orderDate=DateTime.Today;

            productName = givenProductName;
            orderSum = givenOrderSum;
        }

        public int GetOrderNumber()
        {
            return orderNumber;
        }
    }
}
