using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Model
{
    public abstract class CommonModel
    {
        public bool IsActive { get; set; }
        public short CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public short UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? SortedBy { get; set; }
        public string Remarks { get; set; }
    }
}
