using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Export.Model
{
    public class WholeSaleClaim
    {
        public string ClaimDate { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public IList<PartyClaim> PartyClaims { get; set; }
        public decimal TotalClaimAmount { get; set; }
    }
}
