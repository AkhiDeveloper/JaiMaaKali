using JaiMaaKali.WinForm.Extension;
using JaiMaaKali.WinForm.Service.DataMining;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Service.ClaimGenerator
{
    public class PurchaseProductClaimGenerator
        : IClaimGenerator<PurchaseProduct>
    {
        private readonly decimal _rate;
        public PurchaseProductClaimGenerator(decimal transport_rate)
        {
            _rate= transport_rate;
        }
        public TransportClaim GetTransportClaim(PurchaseProduct input_object)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransportClaim> GetTransportClaims(IEnumerable<PurchaseProduct> input_objects)
        {
            var rawbills = input_objects.Distinct(new PurchaseBillComparer());
            var claims = rawbills.Select(x => new TransportClaim()
            { 
                BillDate = x.InvoiceDate,
                BillNumber = x.InvoiceNumber,
                Cartoon = x.Remarks.GetStartingNumber(),
                Rate = _rate,
            });
            return claims.Where(x => x.Cartoon > 0);
        }


    }

    internal class PurchaseBillComparer : IEqualityComparer<PurchaseProduct>
    {
        public bool Equals(PurchaseProduct? x, PurchaseProduct? y)
        {
            if (x.InvoiceNumber.ToLower().Equals(y.InvoiceNumber.ToLower()))
                return true;

            return false;
        }

        public int GetHashCode([DisallowNull] PurchaseProduct obj)
        {
            return obj.InvoiceNumber.GetHashCode();
        }
    }
}
