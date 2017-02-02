using System;

namespace RMS.Model
{
    public class Purchase : PurchaseDetail
    {
        public int PurchaseId { get; set; }
        public short SupplierId { get; set; }
        public string InvoiceNumber { get; set; }
        public int? InvoiceFileId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? PaidAmount { get; set; }

        // PurchaseInvoiceFile Model
        // public int InvoiceFileId { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public byte[] InvoiceFile { get; set; }
    }
}
