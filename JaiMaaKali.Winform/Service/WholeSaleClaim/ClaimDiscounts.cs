using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Service.WholeSaleClaim
{
    public class ClaimDiscounts
    {
        private IList<Tuple<decimal, decimal>> _discountList;


        public ClaimDiscounts(decimal amount, decimal discount) : this()
        {
            _discountList.Add(Tuple.Create(amount, discount));
        }

        public ClaimDiscounts()
        {
            _discountList = new List<Tuple<decimal, decimal>>();
        }

        public void AddDiscounts(decimal amount, decimal discount)
        {
            var existedAmount = _discountList.FirstOrDefault(x => x.Item1 == amount);
            if (existedAmount != null) {
                _discountList.Remove(existedAmount);
            }
            _discountList.Add(Tuple.Create(amount, discount));
        }

        //This is not in percentage
        public decimal GetDiscountRate(decimal amount)
        {
            var amount_rate = _discountList.Where(x => x.Item1 <= amount).OrderBy(x => x.Item1).LastOrDefault();
            if(amount_rate == null)
            {
                return 0;
            }
            return amount_rate.Item2;  
        }

    }
}
