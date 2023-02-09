using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Data.Model
{
    public class PartyClaimCriteria
    {
        public int SN { get; set; }
        public string PartyName { get; set; }
        public string PAN { get; set; }
        public decimal MinClaimAmount { get; set; }
        public decimal AvgClaimAmount { get; set; }
        public decimal MaxClaimAmount { get; set; }
    }
}
