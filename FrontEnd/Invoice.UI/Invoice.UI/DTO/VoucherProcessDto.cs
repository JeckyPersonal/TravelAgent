using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.DTO
{
    internal class VoucherProcessDto
    {
        public List<int> VoucherIds { get; set; }
        public List<int> ExcludedDetailId { get; set; }
    }
}
