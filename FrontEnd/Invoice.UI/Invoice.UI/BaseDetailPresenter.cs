using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI
{
    public abstract class BaseDetailPresenter : BasePresenter
    {
        protected BaseDetailPresenter():base() { }

        public abstract bool DeleteRecord(DataRow id);
    }
}
