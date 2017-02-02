using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Model
{
    public class Sale:SaleDetail
    {
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public byte PaymentMethod { get; set; }
        public bool IsActive { get; set; }
        public short CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public short? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? SortedBy { get; set; }
        public string Remarks { get; set; }
        public string CustomerUsername { get; set; }

    }
}
