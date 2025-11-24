using Invoice.Test.Model.Company;
using Invoice.UI.DTO;
using Invoice.UI.Rental;
using Invoice.UI.UtilsUI.GridSelection;
using System;
using System.Collections.Generic;
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
            this._paymentDto.Id = Convert.ToInt32(this.Tag);
            this._paymentDto.CGST = Convert.ToDouble(txtCGST.Text);
            this._paymentDto.SGST = Convert.ToDouble(txtSGST.Text);
            this._paymentDto.IGST = Convert.ToDouble(txtIGST.Text);
            this._paymentDto.TDS = Convert.ToDouble(txtTDS.Text);
            this._paymentDto.ReceivedAmount = Convert.ToDouble(txtReceiveAmount.Text);
            this._paymentDto.PaymentAmount = Convert.ToDouble(txtReceiveAmount.Text);
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
            this.Tag = this._paymentDto.Id;
            this.txtCGST.Text = this._paymentDto.CGST.ToString("F2");
            this.txtSGST.Text = this._paymentDto.SGST.ToString("F2");
            this.txtIGST.Text = this._paymentDto.IGST.ToString("F2");
            this.txtTDS.Text = this._paymentDto.TDS.ToString("F2");
            this.txtReceiveAmount.Text = this._paymentDto.ReceivedAmount.ToString("F2");
            this.txtInvoiceAmount.Text = this._paymentDto.PaymentAmount.ToString("F2");
            this.txtReferenceNo.Text = this._paymentDto.ReferenceNumber;
            this.dtpPaymentDate.Value = this._paymentDto.ReveivedDate;

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
            List<InvoiceDto> vouchers = this._gridSelectionPresenter.OpenUI();
            //this._paymentPresenter.ShowInvoiceOfCustomer();
        }

        public CustomerDto GetSelectedCustomer()
        {
            if (cmbCustomer.SelectedIndex == -1) return null;

            return cmbCustomer.SelectedItem as CustomerDto;
        }
    }
}
