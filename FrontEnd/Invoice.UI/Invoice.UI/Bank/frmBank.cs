using Invoice.DTO;
using Invoice.Test.Model.Company;
using Invoice.UI.Bank.BankDetail;
using Invoice.UI.Company;
using Invoice.UI.CustomControl;
using Invoice.UI.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.Bank
{
    public partial class frmBank : TitledForm, IBankView
    {
        private BankPresenter _presenter;
        private BankDto _dto;
        private ActionMode _actionMode;
        private bool _isError = false;

        public frmBank(BankPresenter presenter)
        {
            InitializeComponent();
            this._presenter = presenter;
            this._presenter.SetView(this);
            this._dto = new BankDto();
        }

        public void ClearUI()
        {
            txtBankName.Clear();
            txtId.Clear();
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
            BankDto bankDto = dto as BankDto;

            if (dto == null || bankDto.Id == 0)
            {
                this._actionMode = ActionMode.New;
                return;
            }

            this._actionMode = ActionMode.Edit;

            txtBankName.Text = bankDto.BankName;
            txtId.Text = bankDto.Id.ToString();
            this._dto = bankDto;
            
            this.btnAccountInfo.Enabled = bankDto.Id > 0;
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
            this.pnlBankInfo.PerformLayout();
            this.PerformLayout();
            this.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._isError = false;
            this._presenter.SaveAndNew();
        }

        private void txtBankName_Leave(object sender, EventArgs e)
        {
            if (sender.Equals(txtBankName))
            {
                this._dto.BankName = txtBankName.Text;
            }
            else if (sender.Equals(txtId))
            {
                if (string.IsNullOrEmpty(txtId.Text))
                    this._dto.Id = 0;
                else
                    this._dto.Id = Convert.ToInt32(txtId.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this._presenter.Close();
        }

        private void btnAccountInfo_Click(object sender, EventArgs e)
        {
            BankDetailPresenter bankDetailPresenter = new BankDetailPresenter(BankDetailRestClient.Instance);
            frmBankDetail bankDetail = new frmBankDetail(bankDetailPresenter, this._dto.Id);
            bankDetailPresenter.OpenNewUI();
        }
    }
}
