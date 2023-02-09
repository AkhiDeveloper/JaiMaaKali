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
            get=> decimal.Round(Amount*(Discount),2,MidpointRounding.ToPositiveInfinity); 
            set=>this.Amount = decimal.Round(value/(Discount),2,MidpointRounding.ToPositiveInfinity); 
        }
    }
}
