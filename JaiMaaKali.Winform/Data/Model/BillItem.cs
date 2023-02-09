using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Data.Model
{
    public class BillItem
    {
        public int SN { get; set; }

        [Required]
        public string Description { get; set; }

        public int Quantity { get; set; }
        public decimal Rate { get; set; }
    }
}
