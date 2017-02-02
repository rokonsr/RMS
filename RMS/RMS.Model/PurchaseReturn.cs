namespace RMS.Model
{
    public class PurchaseReturn : CommonModel
    {
        public int PurchaseReturnId { get; set; }
        public int PurchaseId { get; set; }
        public short ProductId { get; set; }
        public decimal ReturnQuantity { get; set; }

        public string SupplierName { get; set; }
        public string ProductName { get; set; }
        public short SupplierId { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal TotalReturnValue { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
