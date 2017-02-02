namespace RMS.Model
{
    //--Created by Ataur-->
    public class SaleLedger:CommonModel
    {
        public int SaleLedgerId { get; set; }
        public int CustomerId { get; set; }
        public string InvoiceNumber { get; set; }
        public byte TransactionType { get; set; }
        public decimal ReceivedAmount { get; set; }
        public decimal CurrentDue { get; set; }
        public decimal TotalBalance { get; set; }

        public string CustomerUsername { get; set; }
    }
}
