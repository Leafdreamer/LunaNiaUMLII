using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class CustomerList
    {
        // Instance Field
        private List<Customer> _customerList;

        // Constructor
        public CustomerList()
        {
            _customerList = new List<Customer>();
        }

        // Methods
        public Customer LookupCustomer(string name)
        {
            foreach (Customer item in _customerList)
            {
                if (name == item.Name)
                    return item;
            }
            return null;
        }

        public void AddCustomer(Customer aCustomer)
        {
            Customer foundCustomer = LookupCustomer(aCustomer.Name);
            if (foundCustomer == null)
                _customerList.Add(aCustomer);
        }

        public void DeleteCustomer(string name)
        {
            Customer item = LookupCustomer(name);
            _customerList.Remove(item);
        }

        public void PrintCustomerList()
        {
            foreach (Customer customer in _customerList)
            {
                Console.WriteLine(customer);
            }
        }

        public void UpdateCustomer(string name, Customer customerToUpdate)
        {
            int upd = 0;
            while (upd < _customerList.Count)
            {
                if (_customerList[upd].Name == name)
                {
                    _customerList[upd] = customerToUpdate;
                    break;
                }
                upd++;
            }
        }

    }
}
