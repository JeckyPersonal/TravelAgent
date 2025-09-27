using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.DTO
{
    public class ItemMasterDto
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public double Rate { get; set; }
        public bool AppliedGST { get; set; }
    }
}
