using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Service.WholeSaleClaim
{
    public class PartyWholeSaleClaimCriteria
    {
        
        private static int _total;
        //Priority
        private int _sN;

        public PartyWholeSaleClaimCriteria()
        {
            _total = +1;
            _sN = _total;
        }

        public int SN { get => _sN; }
        public Customer Party { get; set; } = new Customer();
        public decimal MinClaimAmount { get; set; }
        public decimal MaxClaimAmount { get; set; }
        public decimal AvgClaimAmount { get; set; }
    }
}
