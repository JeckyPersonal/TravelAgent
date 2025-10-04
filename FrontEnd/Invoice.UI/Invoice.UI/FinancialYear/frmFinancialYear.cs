using Invoice.Test.Model.Company;
using Invoice.UI.CustomControl;
using Invoice.UI.DTO;
using System;
using System.Windows.Forms;

namespace Invoice.UI.FinancialYear
{
    internal partial class frmFinancialYear : TitledForm, IFinancialYearView
    {

        private ActionMode _actionMode;
        private FinancialYearDto _dto;
        private readonly FinancialYearPresenter _presenter;

        public frmFinancialYear(FinancialYearPresenter presenter)
        {
            InitializeComponent();
            this._dto = new FinancialYearDto();
            this._presenter = presenter;
            this._presenter.SetView(this);
        }

        public void ClearUI()
        {
            this.txtId.Text = "0";
            this.dtpFromDate.Value = DateTime.Now;
            this.dtpToDate.Value = DateTime.Now;
        }

        public DialogResult CloseUI()
        {
            DialogResult result = this.DialogResult;
            this.Close();
            return result;
        }

        public object GetDto()
        {
            return this._dto;
        }

        public ActionMode GetMode()
        {
            return this._actionMode;
        }

        public void SetDto(object dto)
        {
            this._dto = dto as FinancialYearDto;

            if (this._dto.Id == 0)
            {
                this._actionMode = ActionMode.New;
                return;
            }

            this.txtId.Text = this._dto.Id.ToString();
            this.dtpFromDate.Value = this._dto.FromDate;
            this.dtpToDate.Value = this._dto.ToDate;

            this._actionMode = ActionMode.Edit;

        }

        public void ShowError(ValidationErrorResponse errorResponse)
        {
            this.flowPanelErrorMessage.Controls.Clear();

            foreach (var item in errorResponse.Errors)
            {
                foreach (string error in item.Value)
                {
                    ErrorMessage errorMessage = new ErrorMessage();
                    errorMessage.Message = error;
                    errorMessage.Dock = DockStyle.Top;
                    errorMessage.Margin = new Padding(0, 3, 0, 3);
                    this.flowPanelErrorMessage.Controls.Add(errorMessage);
                }
            }

            this.flowPanelErrorMessage.Visible = true;
            this.pnlData.PerformLayout();
            this.PerformLayout();
            this.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._presenter.SaveAndNew();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this._presenter.Close();
        }

        private void dtpToDate_Leave(object sender, EventArgs e)
        {
            if (sender.Equals(txtId))
            {
                int id = 0;
                if(int.TryParse(txtId.Text, out id))
                {
                    this._dto.Id = id;
                }
            }
            else if (sender.Equals(dtpFromDate))
            {
                this._dto.FromDate = dtpFromDate.Value;
            }
            else if (sender.Equals(dtpToDate))
            {
                this._dto.ToDate = dtpToDate.Value;
            }
        }
    }
}
