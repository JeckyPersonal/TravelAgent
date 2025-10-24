using Invoice.Test.Model.Company;
using Invoice.UI.CustomControl;
using Invoice.UI.DTO;
using Invoice.UI.Rental;
using Invoice.UI.UtilsUI.GridSelection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Invoice.UI.InvoiceModule
{
    internal partial class frmInvoice : TitledForm, IInvoiceView
    {
        private ActionMode _mode;
        private InvoiceDto _invoiceDto;
        private IDataGridFormatter _detailGridFormatter;
        private readonly InvoicePresenter _presenter;
        private readonly GridSelectionPresenter<VoucherMasterDto> _gridSelectionPresenter;
        public frmInvoice(InvoicePresenter presenter, GridSelectionPresenter<VoucherMasterDto> gridSelectionPresenter)
        {
            InitializeComponent();
            this._invoiceDto = new InvoiceDto();
            this._presenter = presenter;
            this._presenter.SetView(this);

            this._gridSelectionPresenter = gridSelectionPresenter;
            this._gridSelectionPresenter.SetView(new frmGridSelection<VoucherMasterDto>("Voucher Selector", this._gridSelectionPresenter));
        }

        public void ClearDetail()
        {
            txtItemName.Clear();
            txtQuantity.Clear();
            txtUnit.Clear();
            txtAmount.Clear();
            txtCGst.Clear();
            txtSGST.Clear();
            txtIGST.Clear();
        }

        public void ClearUI()
        {
            txtInvoiceId.Clear();
            txtInvoiceNo.Clear();
            dtpInvoiceDate.Value = DateTime.Now;
            this._invoiceDto = new InvoiceDto();
            this.ClearDetail();
        }

        public DialogResult CloseUI()
        {
            DialogResult result = this.DialogResult;
            this.Close();
            return result;
        }

        public object GetDto()
        {
            this._invoiceDto.Id = string.IsNullOrEmpty(txtInvoiceId.Text) ? 0 : Convert.ToInt32(txtInvoiceId.Text);
            this._invoiceDto.InvoiceNo = txtInvoiceNo.Text;
            this._invoiceDto.InvoiceDate = dtpInvoiceDate.Value;
            this._invoiceDto.Total = Convert.ToDouble(txtTotalAmount.Text);
            this._invoiceDto.CGST = Convert.ToDouble(txtTotalCGST.Text);
            this._invoiceDto.SGST = Convert.ToDouble(txtTotalSGST.Text);
            this._invoiceDto.IGST = Convert.ToDouble(txtTotalIGST.Text);
            this._invoiceDto.Amount = Convert.ToDouble(txtNetAmount.Text);

            //Set Customer
            CustomerDto customer = this.cmbCustomer.SelectedItem as CustomerDto;
            this._invoiceDto.CustomerName = customer.Name;
            this._invoiceDto.CustomerId = customer.Id;

            //SetBank
            BankDto selectedBank = this.GetSelectedBank();
            this._invoiceDto.BankName = selectedBank.BankName;
            this._invoiceDto.BankId = selectedBank.Id;

            //SetAccount
            BankDetailDto selectedBankDetail = this.cmbAccountNo.SelectedItem as BankDetailDto;
            this._invoiceDto.AccountNumberId = selectedBankDetail.Id;
            this._invoiceDto.AccountNumber = selectedBankDetail.AccountNumber;

            return this._invoiceDto;
        }

        public ActionMode GetMode()
        {
            return _mode;
        }

        public void SetDto(object dto)
        {
            this._invoiceDto = dto as InvoiceDto;
            if (this._invoiceDto.Id == 0)
            {
                this._mode = ActionMode.New;
                return;
            }

            txtInvoiceId.Text = this._invoiceDto.Id.ToString();
            txtInvoiceNo.Text = this._invoiceDto.InvoiceNo;
            dtpInvoiceDate.Value = this._invoiceDto.InvoiceDate;
            txtTotalAmount.Text = this._invoiceDto.Total.ToString();
            txtTotalCGST.Text = this._invoiceDto.CGST.ToString();
            txtTotalSGST.Text = this._invoiceDto.SGST.ToString();
            txtTotalIGST.Text = this._invoiceDto.IGST.ToString();
            txtNetAmount.Text = this._invoiceDto.Amount.ToString();

            this.selectCustomer(new CustomerDto() { Name = this._invoiceDto.CustomerName, Id = this._invoiceDto.CustomerId });
            cmbBank.SelectedValue = this._invoiceDto.BankId;
            cmbAccountNo.SelectedValue = this._invoiceDto.AccountNumberId;
            this._presenter.SetInvoiceDetail(this._invoiceDto.Id);

            this._mode = ActionMode.Edit;
        }

        private void selectCustomer(CustomerDto customer)
        {
            if (this.cmbCustomer.Items.Count == 0)
            {
                List<CustomerDto> list = new List<CustomerDto>() { customer };
                this.SetCustomerSource(list);
            }
            else
            {
                List<CustomerDto> existingDataSource = this.cmbCustomer.DataSource as List<CustomerDto>;
                var customerByName = existingDataSource.FirstOrDefault(x => x.Name.Equals(customer.Name));
                if (customerByName != null)
                {
                    existingDataSource.Add(customer);
                }
            }

            this.cmbCustomer.SelectedValue = customer.Id;
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

        public void ClearDetailUI()
        {
            throw new NotImplementedException();
        }

        public void SetCustomerSource(List<CustomerDto> customers)
        {
            this.cmbCustomer.DataSource = customers;
            this.cmbCustomer.DisplayMember = "Name";
            this.cmbCustomer.ValueMember = "Id";
        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            this._presenter.LoadCustomer();
            this._presenter.LoadBank();
            this.cmbBank.SelectedValue = this._invoiceDto.BankId;

            if (this._mode != ActionMode.Edit)
                this.ClearUI();
        }

        private void btnShowVoucher_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.Items.Count == 0 || cmbCustomer.SelectedIndex == -1) return;

            List<VoucherMasterDto> vouchers = this._gridSelectionPresenter.OpenUI();
            this._presenter.ProcessVoucher(vouchers);
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex != -1)
            {
                CustomerDto selectedCustomer = cmbCustomer.SelectedValue as CustomerDto;
                this._gridSelectionPresenter.SetEntityLoader(new VoucherLoaderByCustomer(VoucherRestClient.Instance, selectedCustomer.Id));
                this.cmbAccountNo.SelectedValue = this._invoiceDto.AccountNumberId;
            }
        }

        public void SetInvoiceDetailGridFormatter(IDataGridFormatter invoiceDetailGridFormatter)
        {
            this._detailGridFormatter = invoiceDetailGridFormatter;
        }

        public void SetInvoiceDetailSource(DataTable detailTable)
        {
            this.dgvData.DataSource = detailTable;
            this._detailGridFormatter.ResizeColumn(this.dgvData);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this._presenter.Close();
        }

        public void SetSummary(double totalAmount, double totalCGST, double totalSGST, double totalIGST, double netAmount)
        {
            txtTotalAmount.Text = totalAmount.ToString("F2");
            txtTotalCGST.Text = totalCGST.ToString("F2");
            txtTotalSGST.Text = totalSGST.ToString("F2");
            txtTotalIGST.Text = totalIGST.ToString("F2");
            txtNetAmount.Text = netAmount.ToString("F2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._presenter.SaveAndNew();
        }

        public void SetVoucherIds(List<int> voucherIds)
        {
            if (voucherIds == null) return;

            this._invoiceDto.Vouchers.AddRange(voucherIds);
        }

        public void SetBankSource(List<BankDto> banks)
        {
            this.cmbBank.DataSource = banks;
            this.cmbBank.DisplayMember = "BankName";
            this.cmbBank.ValueMember = "Id";
        }

        private void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBank.SelectedIndex == -1) return;

            this._presenter.LoadAccountNumber();
        }

        public BankDto GetSelectedBank()
        {
            if (cmbBank.SelectedIndex == -1) return null;

            return cmbBank.SelectedItem as BankDto;
        }

        public void SetBankDetailDataSource(List<BankDetailDto> bankDetail)
        {
            this.cmbAccountNo.DataSource = bankDetail;
            this.cmbAccountNo.DisplayMember = "AccountNumber";
            this.cmbAccountNo.ValueMember = "Id";
        }
    }
}
