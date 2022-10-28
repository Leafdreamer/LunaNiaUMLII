using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Pizza
    {
        private int _pizzaNo;
        private string _pizzaSize;
        private double _pizzaPrice;

        // Properties

        public int PizzaNo
        {
            get { return _pizzaNo; }
        }

        public string PizzaSize
        {
            get { return _pizzaSize; }
        }

        public double PizzaPrice
        {
            get { return _pizzaPrice; }
        }

        // Constructor

        public Pizza(int pizzaNo, string pizzaSize, double pizzaPrice)
        {
            _pizzaNo = pizzaNo;
            _pizzaSize = pizzaSize;
            _pizzaPrice = pizzaPrice;
        }

        // Methods

        public override string ToString()
        {
            return $"Pizza no. {_pizzaNo}, size {_pizzaSize}, cost {_pizzaPrice}";
        }



    }
}
