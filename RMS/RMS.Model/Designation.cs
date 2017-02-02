using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Model
{
    //Created by Ataur
    public class Designation : CommonModel
    {
        public byte DesignationId { get; set; }
        public string DesignationName { get; set; }
        public short UserId { get; set; }
    }
}
