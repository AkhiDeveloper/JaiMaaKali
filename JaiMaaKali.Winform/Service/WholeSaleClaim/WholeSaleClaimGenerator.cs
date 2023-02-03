using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Service.WholeSaleClaim
{
    public class WholeSaleClaimGenerator
    {
        private readonly IList<PartyWholeSaleClaimCriteria> _criteria;
        private readonly ClaimDiscounts _claimDiscounts;
        public IList<PartyClaim> _knownPartyClaims;

        public WholeSaleClaimGenerator(
            IList<PartyWholeSaleClaimCriteria> criteria, 
            ClaimDiscounts claimDiscounts)
        {
            _criteria = criteria;
            _claimDiscounts = claimDiscounts;
            _knownPartyClaims= new List<PartyClaim>();
        }

        public void AddKnownPartyClaim(PartyClaim claim)
        {
            _knownPartyClaims.Add(claim);
        }

        public WholeSaleClaim GenerateClaim(
            int year,
            int month,
            decimal finalamount, 
            decimal positive_tolerance = 0.00m, 
            decimal negative_tolerance = 0.00m)
        {
            var claim = new WholeSaleClaim(year, month);
            claim.AddPartyClaims(_knownPartyClaims);
            var remainder_amount = finalamount - claim.TotalClaimAmount;
            var upperlimit = finalamount + positive_tolerance;
            var lowerlimit = finalamount - negative_tolerance > 0 ? finalamount - negative_tolerance : 0;
            var rem_upperlimit = upperlimit - claim.TotalClaimAmount;
            var rem_lowerlimit = lowerlimit - claim.TotalClaimAmount > 0 ? lowerlimit - claim.TotalClaimAmount : 0;

            //no requried to add new parties
            if(rem_upperlimit <= 0)
                return claim;

            //getting remaining parties criteria
            var criteria = UnknownPartyCriteria();
            if(criteria == null || criteria.Count() < 1)
                return claim;
            var minClaim = criteria.Sum(x => x.MinClaimAmount);
            var maxClaim = criteria.Sum(x => x.MaxClaimAmount);
            var totalAvgClaim = criteria.Sum(x => x.AvgClaimAmount);

            //all parties with maximum allowable claim amount should add
            if(rem_lowerlimit > maxClaim)
            {
                if (maxClaim < rem_upperlimit)
                {
                    claim.AddPartyClaims(criteria.Select(x => new PartyClaim()
                    {
                        Party = x.Party,
                        Discount = _claimDiscounts.GetDiscountRate(x.MaxClaimAmount),
                        ClaimAmount = x.MaxClaimAmount,
                    }));
                    return claim;
                }
            }

            //some parties need to remove
            if(rem_upperlimit < minClaim)
            {
                foreach(var p in criteria)
                {
                    if (claim.TotalClaimAmount + p.MinClaimAmount > upperlimit)
                        break;
                    claim.AddPartyClaim(new PartyClaim()
                    {
                        Party = p.Party,
                        Discount = _claimDiscounts.GetDiscountRate(p.MinClaimAmount),
                        ClaimAmount = p.MinClaimAmount,
                    });
                }
                return claim;
            }

            //all parties with average need to calculate according to proportion
            claim.AddPartyClaims(criteria.Select(x => new PartyClaim()
            {
                Party = x.Party,
                Discount = _claimDiscounts.GetDiscountRate(x.AvgClaimAmount/totalAvgClaim*remainder_amount),
                ClaimAmount = x.AvgClaimAmount / totalAvgClaim * remainder_amount,
            }));
            return claim;

        }

        public IEnumerable<PartyWholeSaleClaimCriteria> UnknownPartyCriteria()
        {
            IList<PartyWholeSaleClaimCriteria> result = new List<PartyWholeSaleClaimCriteria>();
            var parties = _criteria.Select(x => x.Party).Except(_knownPartyClaims.Select(x => x.Party));
            foreach(var p in parties)
            {
                if (_criteria.FirstOrDefault(x => x.Party.Id == p.Id) == null)
                    continue;
                result.Add(_criteria.FirstOrDefault(x=>x.Party.Id == p.Id));
            }
            return result;
        }

    }
}
