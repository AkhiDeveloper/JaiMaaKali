using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Service.ClaimGenerator
{
    public class TransportClaim
    {
        public DateTime BillDate { get; set; }
        public string BillNumber { get; set; }
        public int Cartoon { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get => Rate * Cartoon;}
    }
}
