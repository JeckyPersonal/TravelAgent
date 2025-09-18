using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Bank.BankDetail
{
    public interface IBankDetailView : IBaseView
    {
        void LoadDetail(DataTable table);
    }
}
