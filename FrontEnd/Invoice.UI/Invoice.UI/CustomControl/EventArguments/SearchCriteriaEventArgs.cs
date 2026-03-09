using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.CustomControl.EventArguments
{
    public enum Action
    {
        Added,
        Removed,
        Change
    }

    public class SearchCriteriaEventArgs : EventArgs
    {
        public string FieldName { get; set; }
        public string Value { get; set; }
        public string Opearator { get; set; }
        public Action Action { get; set; }
    }
}
