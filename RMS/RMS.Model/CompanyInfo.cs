using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Model
{
    public class CompanyInfo
    {
        public byte CompanyId { get; set; }
        public string CompanyName { get; set; }
        public byte[] CompanyLogo { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyFax { get; set; }
        public string CompanyEmail { get; set; }
        public string TradeLicense { get; set; }
        public string TINCertificate { get; set; }
        public string BSTIApproval { get; set; }
        public string VATRegNumber { get; set; }
    }
}
