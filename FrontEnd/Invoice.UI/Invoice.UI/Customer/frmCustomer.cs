using Invoice.Test.Model.Company;
using Invoice.UI.CustomControl;
using Invoice.UI.Customer.RateConfiguration;
using Invoice.UI.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.Customer
{
    internal partial class frmCustomer : TitledForm, ICustomerView
    {
        private readonly CustomerPresenter _presenter;
        private CustomerDto _dto;
        private ActionMode _actionMode;
        private bool _isError = false;

        public frmCustomer(CustomerPresenter presenter)
        {
            InitializeComponent();
            this._presenter = presenter;
            this._presenter.SetView(this);
        }

        public void ClearUI()
        {
            txtId.Clear();
            txtCompanyName.Clear();
            txtAddress1.Clear();
            txtAddress2.Clear();
            txtAddress3.Clear();
            txtCity.Clear();
            txtState.Clear();
            txtCountry.Clear();
            txtZipCode.Clear();
            txtPhone.Clear();
            txtGST.Clear();
            txtPan.Clear();
            txtCess.Clear();
            radGST.Checked = false;
            radLUT.Checked = true;
            radRCM.Checked = false;
            radWithGST.Checked = false;
            radWithoutGST.Checked = true;
            this._dto = new CustomerDto();
        }

        public DialogResult ShowMessage()
        {
            return MessageBox.Show(
                "Customer detail save successfully. Would you like to add Rate detail?",
                "Customer Detail",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
        }

        public DialogResult CloseUI()
        {
            DialogResult result = this.DialogResult;
            this.Close();
            return result;
        }

        public object GetDto()
        {
            int.TryParse(txtId.Text, out var id);
            this._dto.Id = id;
            this._dto.Name = txtCompanyName.Text;
            this._dto.Address1 = txtAddress1.Text;
            this._dto.Address2 = txtAddress2.Text;
            this._dto.Address3 = txtAddress3.Text;
            this._dto.City = txtCity.Text;
            this._dto.State = txtState.Text;
            this._dto.Country = txtCountry.Text;
            this._dto.Zip = txtZipCode.Text;
            this._dto.PANNo = txtPan.Text;
            this._dto.PhoneNumber = txtPhone.Text;
            this._dto.GSTNo = txtGST.Text;
            this._dto.CessNo = txtCess.Text;
            this._dto.TaxCategory = this.getTaxCategory();
            this._dto.InvoiceFormat = this.GetInvoiceFormat();
            return this._dto;
        }

        private InvoiceFormat GetInvoiceFormat()
        {
            if (radWithGST.Checked)
            {
                return InvoiceFormat.WITH_GST;
            }
            else if (radWithoutGST.Checked)
            {
                return InvoiceFormat.WITHOUT_GST;
            }

            return InvoiceFormat.NONE;
        }

        private TaxCategory getTaxCategory()
        {
            if (radGST.Checked)
            {
                return TaxCategory.GST;
            }
            else if (radRCM.Checked)
            {
                return TaxCategory.RCM;
            }
            else if (radLUT.Checked)
            {
                return TaxCategory.LUT;
            }

            return TaxCategory.NONE;
        }

        public ActionMode GetMode()
        {
            return this._actionMode;
        }

        public void SetDto(object dto)
        {
            this._dto = dto as CustomerDto;

            if (this._dto == null || this._dto.Id == 0)
            {
                this._actionMode = ActionMode.New;
                return;
            }

            txtId.Text = this._dto.Id.ToString();
            txtCompanyName.Text = this._dto.Name;
            txtAddress1.Text = this._dto.Address1;
            txtAddress2.Text = this._dto.Address2;
            txtAddress3.Text = this._dto.Address3;
            txtCity.Text = this._dto.City;
            txtState.Text = this._dto.State;
            txtCountry.Text = this._dto.Country;
            txtZipCode.Text = this._dto.Zip;
            txtPhone.Text = this._dto.PhoneNumber;
            txtGST.Text = this._dto.GSTNo;
            txtPan.Text = this._dto.PANNo;
            txtCess.Text = this._dto.CessNo;
            this.setTaxCategory(this._dto.TaxCategory);
            this.setInvoiceFormat(this._dto.InvoiceFormat);

            this._actionMode = ActionMode.Edit;
        }

        private void setInvoiceFormat(InvoiceFormat invoiceFormat)
        {
            switch (invoiceFormat)
            {
                case InvoiceFormat.WITH_GST:
                    radWithGST.Checked = true;
                    break;
                case InvoiceFormat.WITHOUT_GST:
                    radWithoutGST.Checked = true;
                    break;
            }
        }


        private void setTaxCategory(TaxCategory taxCategory)
        {
            switch (taxCategory)
            {
                case TaxCategory.GST:
                    radGST.Checked = true;
                    break;
                case TaxCategory.RCM:
                    radRCM.Checked = true;
                    break;
                case TaxCategory.LUT:
                    radLUT.Checked = true;
                    break;

            }
        }

        public void ShowError(ValidationErrorResponse errorResponse)
        {
            this._isError = true;
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

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (sender.Equals(txtId))
            {
                if (!string.IsNullOrWhiteSpace(txtId.Text))
                    this._dto.Id = Convert.ToInt32(txtId.Text);
            }
            else if (sender.Equals(txtCompanyName))
            {
                this._dto.Name = txtCompanyName.Text;
            }
            else if (sender.Equals(txtAddress1))
            {
                this._dto.Address1 = txtAddress1.Text;
            }
            else if (sender.Equals(txtAddress2))
            {
                this._dto.Address2 = txtAddress2.Text;
            }
            else if (sender.Equals(txtAddress3))
            {
                this._dto.Address3 = txtAddress3.Text;
            }
            else if (sender.Equals(txtCity))
            {
                this._dto.City = txtCity.Text;
            }
            else if (sender.Equals(txtState))
            {
                this._dto.State = txtState.Text;
            }
            else if (sender.Equals(txtCountry))
            {
                this._dto.Country = txtCountry.Text;
            }
            else if (sender.Equals(txtZipCode))
            {
                this._dto.Zip = txtZipCode.Text;
            }
            else if (sender.Equals(txtPan))
            {
                this._dto.PANNo = txtPan.Text;
            }
            else if (sender.Equals(txtPhone))
            {
                this._dto.PhoneNumber = txtPhone.Text;
            }
            else if (sender.Equals(txtGST))
            {
                this._dto.GSTNo = txtGST.Text;
            }
            else if (sender.Equals(txtCess))
            {
                this._dto.CessNo = txtCess.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._presenter.SaveAndNew();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this._presenter.Close();
        }

        private void btnAddRateInfo_Click(object sender, EventArgs e)
        {
            CustomerRateConfigurationPresenter presenter = new CustomerRateConfigurationPresenter(Item.ItemRestClient.Instance, 
                Vehicle.RateConfiguration.CustomerRateConfigurationRestClient.CustomerInstance, 
                Vehicle.VehicleRestClient.Instance, 
                Vehicle.RateConfiguration.VehicleRateConfigDataGridFormatter.Instance);
            frmCustomerRateConfiguration rateConfiguratino = new frmCustomerRateConfiguration(presenter, this._dto.Id, this._dto.Name);
            presenter.OpenNewUI();
        }

        private void radLUT_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.Equals(radGST))
            {
                this.radWithGST.Checked = true;
                pnlInvoiceFomat.Enabled = true;
            }
            else
            {
                this.radWithoutGST.Checked = true;
                this.pnlInvoiceFomat.Enabled = false;
            }
        }
    }
}
