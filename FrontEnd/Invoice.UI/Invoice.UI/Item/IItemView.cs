using Invoice.UI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Item
{
    internal interface IItemView : IBaseView
    {
        void SetIntervalSource(List<ItemIntervalDto> intervals);
        void SetSource(List<string> intervals);
        void SetType(List<string> intervals);
    }
}
