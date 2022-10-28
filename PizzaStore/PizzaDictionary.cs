using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class PizzaDictionary
    {
        // Instance Field
        private Dictionary<int, Pizza> _pizzaList;

        // Constructor
        public PizzaDictionary()
        {
            _pizzaList = new Dictionary<int, Pizza>();
        }

        // Methods
        public Pizza LookupPizza(int pizzaNo)
        {
            if (_pizzaList.ContainsKey(pizzaNo))
                return _pizzaList[pizzaNo];
            return null;
        }

        public void AddPizza(Pizza aPizza)
        {
            if (!_pizzaList.ContainsKey(aPizza.PizzaNo))
                _pizzaList.Add(aPizza.PizzaNo, aPizza);
        }

        public void DeletePizza(int pizzaNo)
        {
            if (_pizzaList.ContainsKey(pizzaNo))
                _pizzaList.Remove(pizzaNo);
        }

        public void PrintPizzaList()
        {
            foreach (Pizza Pizza in _pizzaList.Values)
            {
                Console.WriteLine(Pizza.ToString());
            }
        }

        public void UpdatePizza(int pizzaNo, Pizza pizzaToUpdate)
        {
            if (_pizzaList.ContainsKey(pizzaNo))
                _pizzaList[pizzaNo] = pizzaToUpdate;
        }

        public bool CheckPizza(int pizzaNo)
        {
            if (_pizzaList.ContainsKey(pizzaNo))
                return true;
            else
                return false;
        }
        
    }
}
