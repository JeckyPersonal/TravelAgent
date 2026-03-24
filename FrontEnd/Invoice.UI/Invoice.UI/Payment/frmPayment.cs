using Invoice.Test.Model.Company;
using Invoice.UI.DTO;
using Invoice.UI.Rental;
using Invoice.UI.UtilsUI.GridSelection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Invoice.UI.Payment
{
    internal partial class frmPayment : TitledForm, IPaymentView
    {
        private PaymentDto _paymentDto;
        private ActionMode _actionMode;
        private readonly PaymentPresenter _paymentPresenter;
        private readonly GridSelectionPresenter<InvoiceDto> _gridSelectionPresenter;
        public frmPayment(PaymentPresenter presenter, GridSelectionPresenter<InvoiceDto> gridSelectionPresenter)
        {
            InitializeComponent();
            this.dtpPaymentDate.CustomFormat = Settings.DateFormat;
            this._paymentDto = new PaymentDto();
            this._actionMode = ActionMode.New;

            this._paymentPresenter = presenter;
            this._paymentPresenter.SetView(this);

            this._gridSelectionPresenter = gridSelectionPresenter;
        }

        public void ClearUI()
        {
            txtCGST.Clear();
            txtIGST.Clear();
            txtReceiveAmount.Clear();
            txtReferenceNo.Clear();
            txtSGST.Clear();
            txtTDS.Clear();
            txtInvoiceAmount.Clear();
            dtpPaymentDate.Value = DateTime.Now;
            cmbCustomer.SelectedIndex = -1;
            this._actionMode = ActionMode.New;
        }

        public DialogResult CloseUI()
        {
            DialogResult result = this.DialogResult;
            this.Close();

            return result;
        }

        public object GetDto()
        {

            double.TryParse(txtInvoiceAmount.Text, out var amount);
            double.TryParse(txtCGST.Text, out var cgst);
            double.TryParse(txtSGST.Text, out var sgst);
            double.TryParse(txtIGST.Text, out var igst);
            double.TryParse(txtTDS.Text, out var tds);
            double.TryParse(txtReceiveAmount.Text, out var receiveAmount);
            double.TryParse(txtInvoiceAmount.Text, out var invoiceAmount);

            this._paymentDto.ReferenceNumber = txtReferenceNo.Text;
            this._paymentDto.Id = Convert.ToInt32(this.Tag);
            this._paymentDto.CGST = cgst;
            this._paymentDto.SGST = sgst;
            this._paymentDto.IGST = igst;
            this._paymentDto.TDS = tds;
            this._paymentDto.ReceivedAmount = receiveAmount;
            this._paymentDto.PaymentAmount = invoiceAmount;
            this._paymentDto.ReveivedDate = this.dtpPaymentDate.Value;

            return _paymentDto;
        }

        public ActionMode GetMode()
        {
            return this._actionMode;
        }

        public void SetDto(object dto)
        {
            this._paymentDto = dto as PaymentDto;

            if (this._paymentDto == null || this._paymentDto.Id == 0)
            {
                this._actionMode = ActionMode.New;
                this.ClearUI();
                return;
            }

            this.Tag = this._paymentDto.Id;
            this.txtCGST.Text = this._paymentDto.CGST.ToString("F2");
            this.txtSGST.Text = this._paymentDto.SGST.ToString("F2");
            this.txtIGST.Text = this._paymentDto.IGST.ToString("F2");
            this.txtTDS.Text = this._paymentDto.TDS.ToString("F2");
            this.txtReceiveAmount.Text = this._paymentDto.ReceivedAmount.ToString("F2");
            this.txtInvoiceAmount.Text = this._paymentDto.PaymentAmount.ToString("F2");
            this.txtReferenceNo.Text = this._paymentDto.ReferenceNumber;
            this.dtpPaymentDate.Value = this._paymentDto.ReveivedDate;

            this._paymentPresenter.LoadDetail(this._paymentDto.Id);

            this._actionMode = ActionMode.Edit;

        }

        public void ShowError(ValidationErrorResponse error)
        {
            throw new NotImplementedException();
        }

        public DialogResult ShowMessage()
        {
            return MessageBox.Show(
                "Payment save successfully.",
                "Payment Advice",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }

        public void SetCustomerSource(List<CustomerDto> customers)
        {
            cmbCustomer.DataSource = customers;
            cmbCustomer.DisplayMember = "Name";
            cmbCustomer.ValueMember = "Id";
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            this._paymentPresenter.LoadAllCustomer();
        }

        private void btnShowVoucher_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.Items.Count == 0 || cmbCustomer.SelectedIndex == -1) return;

            this._gridSelectionPresenter.SetEntityLoader(new InvoiceLoader(InvoiceModule.InvoiceRestClient.Instance));
            this._gridSelectionPresenter.SetView(new frmGridSelection<InvoiceDto>("Invoice Selector", this._gridSelectionPresenter));
            List<InvoiceDto> invoices = this._gridSelectionPresenter.OpenUI();
            if(this._gridSelectionPresenter.IsSuccess())
            {
                this._paymentPresenter.AddInvoices(invoices);
            }
        }

        public CustomerDto GetSelectedCustomer()
        {
            if (cmbCustomer.SelectedIndex == -1) return null;

            return cmbCustomer.SelectedItem as CustomerDto;
        }

        public void SetPaymentDetailSource(DataTable invoiceDetailTable, IDataGridFormatter dataGridFormatter)
        {
            this.dgvPayment.DataSource = invoiceDetailTable;
            dataGridFormatter.ResizeColumn(this.dgvPayment);
        }

        public void SetInvoiceAmount(double amount)
        {
            txtInvoiceAmount.Text = amount.ToString("F2");
            txtReceiveAmount.Text = txtInvoiceAmount.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this._paymentPresenter.Close();
        }

        private void txtIGST_Leave(object sender, EventArgs e)
        {
            double.TryParse(txtInvoiceAmount.Text, out var amount);
            double.TryParse(txtCGST.Text, out var cgst);
            double.TryParse(txtSGST.Text, out var sgst);
            double.TryParse(txtIGST.Text, out var igst);
            double.TryParse(txtTDS.Text, out var tds);

            double receivedAmount = amount - cgst - igst - sgst - tds;

            txtReceiveAmount.Text = receivedAmount.ToString("F2");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._paymentPresenter.SaveAndNew();
        }
    }
}
