using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Service.ClaimGenerator
{
    public interface IClaimGenerator<T> 
        where T : class
    {
        TransportClaim GetTransportClaim(T input_object);

        IEnumerable<TransportClaim> GetTransportClaims(IEnumerable<T> input_objects);
    }
}
