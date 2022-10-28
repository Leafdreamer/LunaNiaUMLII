using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Customer
    {
        private string _name;
        private string _address;
        private string _phone;

        // Properties

        public string Name
        {
            get { return _name; }
        }

        public string Address
        {
            get { return _address; }
        }

        public string Phone
        {
            get { return _phone; }
        }


        // Constructor

        public Customer(string name, string address, string phone)
        {
            _name = name;
            _address = address;
            _phone = phone;
        }

        // Methods

        public override string ToString()
        {
            return $"{_name}, {_address}, {_phone}";
        }




    }
}
