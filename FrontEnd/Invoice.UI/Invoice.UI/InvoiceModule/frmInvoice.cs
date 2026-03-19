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
        private TenderDto _tenderDto;
        private IDataGridFormatter _detailGridFormatter;
        private readonly InvoicePresenter _presenter;
        private readonly GridSelectionPresenter<VoucherMasterDto> _gridSelectionPresenter;
        private InvoiceDetailDto _currentDetailDto;
        public frmInvoice(InvoicePresenter presenter, GridSelectionPresenter<VoucherMasterDto> gridSelectionPresenter) : base()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(950, 600);
            this._invoiceDto = new InvoiceDto();
            this._presenter = presenter;
            this._presenter.SetView(this);

            this._gridSelectionPresenter = gridSelectionPresenter;
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
            btnSave.Tag = null;
            txtItemName.Tag = null;
            txtItemDescription.Clear();
        }

        public void ClearUI()
        {
            txtInvoiceId.Clear();
            txtInvoiceNo.Clear();
            dtpInvoiceDate.Value = DateTime.Now;
            this._invoiceDto = new InvoiceDto();
            this.ClearDetail();
        }

        public DialogResult ShowMessage()
        {
            return MessageBox.Show(
                "Invoice detail save successfully.",
                "Invoice Detail",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }

        public void ShowErrorPopupMessage(string message) 
        {
            MessageBox.Show(
                message,
                "Invoice",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
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

            this._presenter.SetCustomerDetail(this._invoiceDto.CustomerId);
            cmbBank.SelectedValue = this._invoiceDto.BankId;
            cmbAccountNo.SelectedValue = this._invoiceDto.AccountNumberId;
            this._presenter.SetInvoiceDetail(this._invoiceDto.Id);

            this._mode = ActionMode.Edit;
        }

        public void SelectCustomer(CustomerDto customerById)
        {
            if (this.cmbCustomer.Items.Count == 0)
            {
                List<CustomerDto> list = new List<CustomerDto>() { customerById };
                this.SetCustomerSource(list);
            }
            else
            {
                List<CustomerDto> existingDataSource = this.cmbCustomer.DataSource as List<CustomerDto>;
                var customerByName = existingDataSource.FirstOrDefault(x => x.Name.Equals(customerById.Name));
                if (customerByName != null)
                {
                    existingDataSource.Add(customerById);
                }
            }

            this.cmbCustomer.SelectedValue = customerById.Id;
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
            this._presenter.LoadItems();
            this.cmbBank.SelectedValue = this._invoiceDto.BankId;

            if (this._mode != ActionMode.Edit)
                this.ClearUI();
        }

        private void btnShowVoucher_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.Items.Count == 0 || cmbCustomer.SelectedIndex == -1) return;

            var gridSector = new frmGridSelection<VoucherMasterDto>("Voucher Selector", this._gridSelectionPresenter);
            this._gridSelectionPresenter.SetView(gridSector);
            List<VoucherMasterDto> vouchers = this._gridSelectionPresenter.OpenUI();

            if (gridSector.DialogResult.Equals(DialogResult.Cancel))
                return;
               
            this._presenter.ProcessVoucher(vouchers);
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex != -1)
            {
                CustomerDto selectedCustomer = cmbCustomer.SelectedItem as CustomerDto;
                this._gridSelectionPresenter.SetEntityLoader(new VoucherLoaderByCustomer(VoucherRestClient.Instance, selectedCustomer.Id));
                this.cmbAccountNo.SelectedValue = this._invoiceDto.AccountNumberId;
                this._presenter.setTenderCharges(selectedCustomer.Id);
            }
        }

        public void ApplyTenderChanges(bool applyChanges, TenderDto tenderDetail)
        {
            btnTender.Visible = applyChanges;
            txtTotalKM.Enabled = applyChanges;
            txtAverageKM.Enabled = applyChanges;
            _tenderDto = tenderDetail;
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

        public void SetItemSource(List<string> itemsString)
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(itemsString.ToArray());
            this.txtItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.txtItemName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.txtItemName.AutoCompleteCustomSource = collection;
        }

        private ItemMasterDto _currentItem = null;

        private void txtItemName_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtItemName.Text) &&
                txtItemName.Text.Contains("(")&&
                sender.Equals(txtItemName))
            {
                int openBrecIndex = txtItemName.Text.LastIndexOf("(");
                string strId = txtItemName.Text.Substring(openBrecIndex + 1).Replace(")", string.Empty);

                int id = 0;
                int.TryParse(strId, out id);
                txtItemName.Tag = id;

                this._presenter.SetItemRates(id);
            }
            else if (
                (!string.IsNullOrEmpty(txtRate.Text) &&
                sender.Equals(txtRate)) ||
                
                (!string.IsNullOrEmpty(txtAmount.Text) &&
                sender.Equals(txtAmount))
                )
            {
                this.calculateGST(this._currentItem);
            }
        }

        public void SetItemInfo(ItemMasterDto itemById)
        {
            this._currentItem = itemById;
            txtRate.Text = itemById.Rate.ToString();
            txtAmount.Text = itemById.Rate.ToString();
            txtUnit.Text = itemById.Unit;
            txtQuantity.Text = itemById.Quantity.ToString();

            calculateGST(itemById);
        }

        private void calculateGST(ItemMasterDto itemById)
        {
            if (itemById.AppliedGST)
            {
                if (this.cmbCustomer.SelectedIndex == -1)
                {
                    txtAmount.Text = txtRate.Text;
                }
                else
                {
                    double.TryParse(txtRate.Text, out var rate);
                    CustomerDto customerDto = this.cmbCustomer.SelectedItem as CustomerDto;

                    if (!string.IsNullOrEmpty(customerDto.CessNo))
                    {
                        txtAmount.Text = txtRate.Text;
                    }
                    else if (!customerDto.GSTNo.StartsWith("24"))
                    {
                        double IGST = (rate * 5) / 105;
                        txtIGST.Text = IGST.ToString("F2");
                        txtRate.Text = (Convert.ToDouble(txtAmount.Text) - IGST).ToString("F2");
                    }
                    else
                    {
                        double GST = ((rate * 5) / 105);
                        txtCGst.Text = txtSGST.Text = GST.ToString("F2");
                        txtRate.Text = (Convert.ToDouble(rate) - GST - GST).ToString("F2");
                        txtAmount.Text = rate.ToString("F2");
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InvoiceDetailDto invoiceDetailDto = new InvoiceDetailDto()
            {
                Id = Convert.ToInt32(btnSave.Tag==null?0:btnSave.Tag),
                ActionMode = ActionMode.New,
                Amount = Convert.ToDouble(txtAmount.Text),
                AmountBeforeGST = Convert.ToDouble(txtRate.Text),
                CGST = string.IsNullOrEmpty(txtCGst.Text) ? 0 : Convert.ToDouble(txtCGst.Text),
                SGST = string.IsNullOrEmpty(txtSGST.Text) ? 0 : Convert.ToDouble(txtSGST.Text),
                IGST = string.IsNullOrEmpty(txtIGST.Text) ? 0 : Convert.ToDouble(txtIGST.Text),
                ItemId = Convert.ToInt32(txtItemName.Tag),
                ItemName = txtItemName.Text,
                Description = txtItemDescription.Text,
                Quantity = Convert.ToInt32(txtQuantity.Text),
                Rate = Convert.ToDouble(txtRate.Text),
                Unit = txtUnit.Text,
                VoucherDetailId = this._currentDetailDto==null?0: this._currentDetailDto.VoucherDetailId,
                VoucherNo = this._currentDetailDto==null?"": this._currentDetailDto.VoucherNo
            };
            if(btnSave.Tag == null)
                this._presenter.AddInvoiceDetailDto(invoiceDetailDto);
            else 
                this._presenter.UpdateInvoiceDetailDto(invoiceDetailDto);
        }

        public DataRow SelectedDetailRow()
        {
            DataRowView rowView = this.dgvData.SelectedRows[0].DataBoundItem as DataRowView;
            return rowView.Row;
        }

        public void DeleteDetailRow() 
        {
            this.dgvData.Rows.Remove(this.dgvData.SelectedRows[0]);
        }

        public void SetInvoiceDetailDto(InvoiceDetailDto detailDto)
        {
            this._currentDetailDto = detailDto;
            this._currentDetailDto.ActionMode = ActionMode.Edit;

            btnSave.Tag = detailDto.Id;
            //ActionMode = ActionMode.New,
            txtAmount.Text = detailDto.Amount.ToString();
            txtRate.Text = detailDto.AmountBeforeGST.ToString();
            txtCGst.Text = detailDto.CGST.ToString();
            txtSGST.Text = detailDto.SGST.ToString();
            txtIGST.Text = detailDto.IGST.ToString();
            txtItemName.Tag = detailDto.ItemId;
            txtItemName.Text = detailDto.ItemName;
            txtItemDescription.Text = detailDto.Description;
            //Description = string.Empty,
            txtQuantity.Text = detailDto.Quantity.ToString();
            txtRate.Text = detailDto.Rate.ToString();
            txtUnit.Text = detailDto.Unit;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this._presenter.PrintInvoice(this._invoiceDto.Id);
        }

        private void btnTender_Click(object sender, EventArgs e)
        {

            if (this._invoiceDto.Vouchers.Count == 0) {
                this.ShowErrorPopupMessage("Please select at leate one voucher. to apply Tender chagnes.");
                return;
            }

            List<int> totalKms= txtTotalKM.Lines
                .Select(x => int.TryParse(x, out int val) ? val : (int?)null)
                .Where(x => x.HasValue)
                .Select(x => x.Value)
                .ToList();

            
            if (totalKms.Count<=0) {
                
                var result = MessageBox.Show("Total k.m not found Fuel differace is not apply. Are you sure you want to continue.", "Tender Charges", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result.Equals(DialogResult.No))
                {
                    txtTotalKM.Focus();
                    return;
                }
            }

            int.TryParse(txtAverageKM.Text, out var averageKm);
            if (averageKm<=0)
            {
                var result = MessageBox.Show("Average k.m not found Fuel differace is not apply. Are you sure you want to continue.", "Tender Charges", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result.Equals(DialogResult.No))
                {
                    txtAverageKM.Focus();
                    return;
                }
            }
            
            if (_tenderDto.CustomerID > 0)
            {

                this._presenter.AddTenderInvoiceDetailDto(new TenderItemsDto()
                {
                    InvoiceDate= DateTime.Now,
                    CustomerId = _tenderDto.CustomerID,
                    TotalKm = totalKms,
                    FixedCost = this._presenter.getTotalFixedCost(),
                    AverageKM = averageKm
                });
            }
            else {
                this.ShowErrorPopupMessage("Tender detail for selected customer is not found.");
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this._presenter.EditDetailDto();
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            if (MessageBox.Show($"Are you sure you want to delete selected Invoice Item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            this._presenter.DeleteInvoiceDetail();
        }
    }
}
