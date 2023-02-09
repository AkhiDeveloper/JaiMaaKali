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

        public void AddKnownPartyClaims(IEnumerable<PartyClaim> claims)
        {
            foreach(var claim in claims)
            {
                AddKnownPartyClaim(claim);
            }
        }

        public WholeSaleClaim GenerateClaim(
            int year,
            int month,
            decimal finalClaimAmount, 
            decimal positive_tolerance = 0.00m, 
            decimal negative_tolerance = 0.00m)
        {
            var min_discountRate = _claimDiscounts.GetDiscountRate(0);
            var claim = new WholeSaleClaim(year, month);
            claim.AddPartyClaims(_knownPartyClaims);
            var remainder_amount = finalClaimAmount - claim.TotalClaimAmount;
            var upperlimit = finalClaimAmount + positive_tolerance;
            var lowerlimit = finalClaimAmount - negative_tolerance > 0 ? finalClaimAmount - negative_tolerance : 0;
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
                        Discount = _claimDiscounts.GetDiscountRate(x.MaxClaimAmount/min_discountRate),
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
                    if(claim.GetPartyClaims().Count() > 0)
                    {
                        if (claim.TotalClaimAmount + p.MinClaimAmount > upperlimit)
                            break;
                    } 
                    claim.AddPartyClaim(new PartyClaim()
                    {
                        Party = p.Party,
                        Discount = _claimDiscounts.GetDiscountRate(p.MinClaimAmount/min_discountRate),
                        ClaimAmount = p.MinClaimAmount,
                    });
                }
                return claim;
            }

            //all parties with average need to calculate according to proportion
            claim.AddPartyClaims(criteria.Select(x => new PartyClaim()
            {
                Party = x.Party,
                Discount = _claimDiscounts.GetDiscountRate(x.AvgClaimAmount/totalAvgClaim*remainder_amount/min_discountRate),
                ClaimAmount = x.AvgClaimAmount / totalAvgClaim * remainder_amount,
            }));
            return claim;

        }

        private IEnumerable<PartyWholeSaleClaimCriteria> UnknownPartyCriteria()
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
