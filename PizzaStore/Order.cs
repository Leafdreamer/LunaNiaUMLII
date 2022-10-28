using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Order
    {
        private static int _orderCounter = 0;
        private int _orderID;
        private string _additionalComment;

        const int tax = 40;

        private Pizza _pizza;

        public Pizza Pizza
        {
            get { return _pizza; }
            set { _pizza = value; }
        }

        private Customer _customer;

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public int OrderID
        {
            get { return _orderID; }
            private set { _orderID = value; }
        }

        public string AdditionalComment
        {
            get { return _additionalComment; }
        }

        public DateTime OrderDate { get; private set; }

        public Order(Pizza pizza, Customer customer, string additionalComment)
        {
            _orderCounter++;
            _orderID = _orderCounter;
            OrderDate = DateTime.Now;
            _pizza = pizza;
            _customer = customer;
            _additionalComment = additionalComment;
        }

        public override string ToString()
        {
            return $"Order no. {_orderID}, Date: {OrderDate.ToString("dd/MM/yyyy")}, " +
                   $"Pizza no. {_pizza.PizzaNo}, size {_pizza.PizzaSize}, cost {_pizza.PizzaPrice + tax} DKK, " +
                   $"Name: {_customer.Name}, Address: {_customer.Address}, Phone: {_customer.Phone}, " +
                   $"{_additionalComment}";

        }

    }
}
