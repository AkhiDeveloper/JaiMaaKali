using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Export.Model
{
    public class PartyClaim
    {
        public int SN { get; set; }
        public string PartyName { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal ClaimAmount { get; set; }
    }
}
