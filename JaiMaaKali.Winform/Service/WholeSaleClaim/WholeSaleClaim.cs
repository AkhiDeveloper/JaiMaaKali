using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiMaaKali.WinForm.Service.WholeSaleClaim
{
    public class WholeSaleClaim
    {
        private IDictionary<int, PartyClaim> _partyClaims;
        private DateTime _createdDate;
        private int _year;
        private int _month;

        public WholeSaleClaim()
        {
            _createdDate = DateTime.Now;
            Year = DateTime.Now.Year;
            Month= DateTime.Now.Month;
            _partyClaims = new Dictionary<int, PartyClaim>();
        }

        public WholeSaleClaim(DateTime createdDate, int year, int month)
        {
            CreatedDate = createdDate;
            Year = year;
            Month = month;
            _partyClaims = new Dictionary<int, PartyClaim>();
        }

        public WholeSaleClaim(int year, int month)
        {
            _createdDate = DateTime.Now;
            Year = year;
            Month = month;
            _partyClaims = new Dictionary<int, PartyClaim>();
        }

        public DateTime CreatedDate
        {
            get { return _createdDate; }
            private set { _createdDate = value; }
        }
        public int Year { 
            get => _year; 
            private set => _year = value; }

        public int Month { 
            get => _month;
            private set {
                if (value < 1 || value > 12)
                    throw new ArgumentOutOfRangeException("Value of Month should be between 1 and 12");
                _month = value;
            }
        }

        public decimal TotalClaimAmount {
            get => decimal.Round(_partyClaims.Sum(x => x.Value.ClaimAmount), 2, MidpointRounding.ToPositiveInfinity);
        }

        public IDictionary<int, PartyClaim> GetPartyClaims()
        {
            return _partyClaims;
        }

        public void AddPartyClaim(PartyClaim party_claim)
        {
            int sn = _partyClaims.Count + 1;
            _partyClaims.Add(new KeyValuePair<int, PartyClaim>(sn, party_claim));
        }

        public void AddPartyClaims(IEnumerable<PartyClaim> partyClaims)
        {
            foreach(var claim in partyClaims)
            {
                AddPartyClaim(claim);
            }
        }
    }
}
