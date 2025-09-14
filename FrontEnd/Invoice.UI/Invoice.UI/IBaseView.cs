using Invoice.Test.Model.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI
{
    public enum ActionMode
    {
        New,
        Edit,
        Select
    }

    public interface IBaseView
    {
        DialogResult ShowDialog();

        void ClearUI();

        DialogResult CloseUI();

        void SetDto(object dto);

        void ShowError(ValidationErrorResponse error);

        ActionMode GetMode();

        DialogResult DialogResult { get; }
    }
}
