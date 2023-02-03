using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Service.WholeSaleClaim
{
    public class PartyClaim
    {
        public Customer Party { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal ClaimAmount 
        { 
            get=>Amount*(1-Discount); 
            set=>this.Amount = value/(1-Discount); 
        }
    }
}
