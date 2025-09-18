using Invoice.Test.Model.Company;
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

namespace Invoice.UI.Bank.BankDetail
{
    public partial class frmBankDetail : TitledForm, IBankDetailView
    {
        private BankDetailDto _bankDetailDto;
        private ActionMode _mode;
        private BankDetailPresenter _presenter;
        private readonly int _bankId;

        public frmBankDetail(BankDetailPresenter presenter, int BankId)
        {
            InitializeComponent();
            this._presenter = presenter;
            this._presenter.SetView(this);
            this._bankId = BankId;
        }

        public void ClearUI()
        {
            txtAccountNumber.Clear();
            txtId.Clear();
            txtIFSCCode.Clear();
            this._bankDetailDto = new BankDetailDto();
            this._bankDetailDto.Id = this._bankId;
        }

        public DialogResult CloseUI()
        {
            DialogResult dialogResult = this.DialogResult;
            this.Close();
            return dialogResult;
        }

        public object GetDto()
        {
            return this._bankDetailDto;
        }

        public ActionMode GetMode()
        {
            return _mode;
        }

        public void SetDto(object dto)
        {
            this._bankDetailDto = dto as BankDetailDto;

            if (_bankDetailDto == null || _bankDetailDto.Id == 0)
            {
                this._mode = ActionMode.New;
                return;
            }

            txtAccountNumber.Text = this._bankDetailDto.AccountNumber;
            txtIFSCCode.Text = this._bankDetailDto.IFSCCode;
            txtId.Text = this._bankDetailDto.Id.ToString();

            this._mode = ActionMode.Edit;
        }

        public void ShowError(ValidationErrorResponse error)
        {
            throw new NotImplementedException();
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            if (this._bankDetailDto.BankId == 0)
            {
                this._bankDetailDto.BankId = this._bankId;
            }
            if (sender.Equals(txtAccountNumber))
            {
                this._bankDetailDto.AccountNumber = txtAccountNumber.Text;
            }
            else if (sender.Equals(txtIFSCCode))
            {
                this._bankDetailDto.IFSCCode = txtIFSCCode.Text;
            }
            else if (sender.Equals(txtId))
            {
                if (!string.IsNullOrEmpty(txtId.Text))
                    this._bankDetailDto.Id = Convert.ToInt32(txtId.Text);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this._presenter.SaveAndNew();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this._presenter.Close();
        }

        private void frmBankDetail_Load(object sender, EventArgs e)
        {
            this._presenter.LoadAllDetail(this._bankId);
        }

        public void LoadDetail(DataTable table)
        {
            this.dgvData.DataSource = table;
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView rowView = this.dgvData.SelectedRows[0].DataBoundItem as DataRowView;
            BankDetailDto dtoToEdit = new BankDetailDto()
            {
                Id = Convert.ToInt32(rowView.Row["Id"]),
                AccountNumber = Convert.ToString(rowView.Row["AccountNumber"]),
                IFSCCode = Convert.ToString(rowView.Row["IFSCCode"]),
                BankId = this._bankId
            };

            this.SetDto(dtoToEdit);
        }
    }
}
