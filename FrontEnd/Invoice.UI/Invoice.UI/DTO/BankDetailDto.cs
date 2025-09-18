using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.DTO
{
    public class BankDetailDto
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }
        public int BankId { get; set; }
    }
}
