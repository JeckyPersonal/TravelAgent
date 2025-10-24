using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.DTO
{
    internal class InvoiceDto
    {
        public InvoiceDto()
        {
            this.Vouchers = new List<int>();
        }

        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int AccountNumberId { get; set; }
        public string AccountNumber { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public int? StartingKM { get; set; }
        public DateTime StartingTime { get; set; }
        public double Total { get; set; }
        public double CGST { get; set; }
        public double SGST { get; set; }
        public double IGST { get; set; }
        public double Amount { get; set; }
        public List<int> Vouchers { get; set; }


    }
}
