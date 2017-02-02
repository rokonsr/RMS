using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Model
{
    public class SaleReturn:CommonModel
    {
        public int SaleReturnId { get; set; }

        public int CustomerId { get; set; }

        public int InvoiceNumber { get; set; }

        public short ProductId { get; set; }

        public decimal ReturnQuantity { get; set; }
        public decimal ReturnAmount { get; set; }

    }
}
