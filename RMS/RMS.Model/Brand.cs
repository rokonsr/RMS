using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Model
{
    public class Brand:CommonModel
    {
        public short BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandDescription { get; set; }

    }
}
