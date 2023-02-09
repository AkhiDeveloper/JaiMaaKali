using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JaiMaaKali.WinForm.Service.Bill;
using JaiMaaKali.WinForm.Service.WholeSaleClaim;

namespace JaiMaaKali.WinForm.Map
{
    public class MappingProfile
        : Profile
    {
        public MappingProfile()
        {
            CreateMap<
                Data.Model.PartyClaimCriteria, 
                Service.WholeSaleClaim.PartyWholeSaleClaimCriteria>()
                .AfterMap((src, dst) =>
                {
                    dst.Party.CustomerName = src.PartyName;
                    dst.Party.PAN = src.PAN;
                });

            CreateMap
                <Data.Model.BillItem,
                Service.Bill.BillItem>().ReverseMap();

            CreateMap
                <IEnumerable<Data.Model.AmountDiscount>,
                Service.WholeSaleClaim.ClaimDiscounts>()
                .AfterMap((src, dst) =>
                {
                    foreach(var x in src)
                    {
                        dst.AddDiscounts(x.Amount, x.DiscountRate);
                    }
                });

            CreateMap<PartyClaim, Export.Model.PartyClaim>()
                .AfterMap((src, dst) =>
                {
                    dst.PartyName = src.Party.CustomerName;
                });
            CreateMap<WholeSaleClaim, Export.Model.WholeSaleClaim>()
               .ForMember(dst => dst.PartyClaims, opt => opt.MapFrom(src => src.GetPartyClaims().Values))
               .AfterMap((src, dst) =>
               {
                   dst.ClaimDate = src.CreatedDate.ToString("yyyy-MM-dd");
                   foreach(var claim in dst.PartyClaims)
                   {
                       claim.SN = src.GetPartyClaims().FirstOrDefault(x => x.Value.Party.CustomerName == claim.PartyName).Key;
                   }
               });

            CreateMap<BillItem, Export.Model.BillItem>();
            CreateMap<Bill, Export.Model.Bill>().AfterMap((src, dst) =>
            {
                dst.BillDate = src.BillDate.ToLongDateString();
                dst.SubTotal = src.GetSubTotal();
                dst.Total = src.GetTotalAmount();
                dst.TaxableValue = src.GetTaxableAmount();
                dst.VATAmount = src.GetTaxAmount();
                dst.Discount = src.GetDiscountAmount();
                dst.PartyName = src.Party.CustomerName;
                dst.Address = src.Party.Address;
                dst.PAN = src.Party.PAN;
            });
            
        }
    }
}
