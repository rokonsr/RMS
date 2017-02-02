using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Model
{
    //Created by Ataur
    public class Role:CommonModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public short UserId { get; set; }
        public string HasRole { get; set; }
        public byte MenuId { get; set; }
    }
}
