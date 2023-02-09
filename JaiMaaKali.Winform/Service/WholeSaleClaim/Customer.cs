using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;
using JaiMaaKali.WinForm.Extension;

namespace JaiMaaKali.WinForm.Service.WholeSaleClaim
{
    public class Customer
    {
        private static int total;
        private readonly int _id;
        private string _customerName;
        public Customer()
        {
            total++;
            _id = total;
        }

        public int Id { get => _id; }
        public string PAN { get; set; }
        public string CustomerName { 
            get => _customerName;
            set
            {
                _customerName = value.RemoveExtraSpace().ToUpper();
            }  
        }
        public string Address { get; set; }
    }
}
