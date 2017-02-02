namespace RMS.Model
{
    public class PurchaseDetail : CommonModel
    {
        public int PurchaseDetailId { get; set; }
        //public int PurchaseId { get; set; }
        public short ProductId { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public decimal PurchasePrice { get; set; }

        public decimal ProductSellPrice { get; set; }
    }
}
