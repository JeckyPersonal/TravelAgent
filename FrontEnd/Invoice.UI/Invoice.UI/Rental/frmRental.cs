using Invoice.Test.Model.Company;
using Invoice.UI.CustomControl;
using Invoice.UI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Invoice.UI.Rental
{
    internal partial class frmRental : TitledForm, IVoucherView
    {

        private ActionMode _mode;
        private readonly VoucherPresenter _presenter;
        private VoucherMasterDto _dto;
        private VoucherDetailGridFormatter _detailGridFomatter;
        private int _oldDays;

        public frmRental(VoucherPresenter presenter)
        {
            var screen = Screen.PrimaryScreen.WorkingArea;
            this.Size = Settings.getScreenRelativeSize();
            
            InitializeComponent();
            this.dtpFromDate.CustomFormat = Settings.DateFormat;
            this.dateTimePicker1.CustomFormat = Settings.DateFormat;
            this.dtpVoucherDate.CustomFormat = Settings.DateFormat;

            this._presenter = presenter;
            this._presenter.SetView(this);
            this._dto = new VoucherMasterDto();
        }

        public void ClearUI()
        {
            this.dtpFromDate.Value = DateTime.Now;
            this.dateTimePicker1.Value = DateTime.Now;
            this.cmbCustomer.SelectedIndex = -1;
            this.cmbRegistration.SelectedIndex = -1;
            this.cmbVehicleType.SelectedIndex = -1;
            this.cmbDriver.SelectedIndex = -1;
            txtVoucherId.Clear();
            txtVoucherNo.Clear();
            txtTotalDays.Text = "1";
            lblVoucherStatus.Text = string.Empty;
            this.txtPickupLocation.Clear();
            this.txtDropLocation.Clear();
            this.maskEndFrom.Clear();
            this.maskStartFrom.Clear();
            this.txtVisitorName.Clear();
            this.radNone.Checked = true;
            this.ClearDetailView();
            this.txtItemDescription.Clear();
        }

        public DialogResult ShowMessage()
        {
            return MessageBox.Show(
                "Voucher detail save successfully.",
                "Voucher Detail",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }

        public void ClearDetailView()
        {
            txtItemName.Clear();
            txtItemDescription.Clear();
            txtQuantity.Clear();
            txtRate.Clear();
            txtUnit.Clear();
            txtAmount.Clear();
            txtInterval.Clear();
            txtInterval.Tag = null;
            txtQuantity.ReadOnly = true;
        }

        public DialogResult CloseUI()
        {
            DialogResult result = this.DialogResult;
            this.Close();
            return result;
        }

        public object GetDto()
        {
            this._dto.CustomerName = cmbCustomer.Text;
            this._dto.DriverName = cmbDriver.Text;
            this._dto.VehicleType = cmbVehicleType.Text;
            this._dto.RegistrationNo = cmbRegistration.Text;
            this._dto.CustomerId = Convert.ToInt32(cmbCustomer.SelectedValue);
            this._dto.VehicleId = Convert.ToInt32(cmbVehicleType.SelectedValue);
            this._dto.RegistrationId = Convert.ToInt32(cmbRegistration.SelectedValue);
            this._dto.DriverId = Convert.ToInt32(cmbDriver.SelectedValue);

            this._dto.FromDate = dtpFromDate.Value;
            this._dto.ToDate = dateTimePicker1.Value;
            this._dto.VoucherDate = dtpFromDate.Value;
            this._dto.PickupLocation = txtPickupLocation.Text;
            this._dto.DropLocation = txtDropLocation.Text;
            this._dto.VoucherNo = txtVoucherNo.Text;
            this._dto.VisitorName = txtVisitorName.Text;
            this._dto.StartFrom = maskStartFrom.Text;
            this._dto.EndFrom = maskEndFrom.Text;
            this._dto.BillingWorkType = this.getBillingWorkType();

            int.TryParse(txtVoucherId.Text, out var voucherId);
            this._dto.Id = voucherId;

            int.TryParse(txtTotalDays.Text, out var totalDays);
            this._dto.Days = totalDays;

            return this._dto;
        }

        private BillingWorkType getBillingWorkType()
        {
            if (radKM.Checked)
            {
                return BillingWorkType.KM;
            }
            else if (radTime.Checked)
            {
                return BillingWorkType.TIME;
            }
            else
            {
                return BillingWorkType.NONE;
            }
        }

        public ActionMode GetMode()
        {
            return this._mode;
        }

        public void SetDto(object dto)
        {
            this._dto = dto as VoucherMasterDto;

            if (this._dto.Id == 0)
            {
                this._mode = ActionMode.New;
                this.ClearUI();
                return;
            }

            cmbCustomer.SelectedText = this._dto.CustomerName;
            cmbDriver.SelectedText = this._dto.DriverName;
            cmbVehicleType.SelectedText = this._dto.VehicleType;
            cmbRegistration.SelectedText = this._dto.RegistrationNo;

            dtpFromDate.Value = this._dto.FromDate;
            dateTimePicker1.Value = this._dto.ToDate;
            //dtpFromDate.Value = this._dto.VoucherDate;
            txtPickupLocation.Text = this._dto.PickupLocation;
            txtDropLocation.Text = this._dto.DropLocation;
            txtVoucherNo.Text = this._dto.VoucherNo;
            txtVoucherId.Text = this._dto.Id.ToString();
            txtTotalDays.Text = this._dto.Days.ToString();
            lblVoucherStatus.Text = this._dto.voucherStatus.ToString();

            this.setBillingWorkType(this._dto.BillingWorkType);
            txtVisitorName.Text = this._dto.VisitorName;
            this.setWorkFromTo();

            int.TryParse(txtTotalDays.Text, out this._oldDays);
            this._mode = ActionMode.Edit;

            this._presenter.SetVoucherDetail();
        }

        private void setWorkFromTo()
        {
            if (this._dto.BillingWorkType != BillingWorkType.NONE)
            {
                maskStartFrom.Text = this._dto.StartFrom;
                maskEndFrom.Text = this._dto.EndFrom;
            }
        }

        private void setBillingWorkType(BillingWorkType billingWorkType)
        {
            switch (billingWorkType)
            {
                case BillingWorkType.KM:
                    radKM.Checked= true;
                    break;
                case BillingWorkType.TIME:
                    radTime.Checked = true;
                    break;
                case BillingWorkType.NONE:
                    radNone.Checked = true; 
                    break;
            }
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

        public void SetCustomerSource(List<CustomerDto> customers)
        {
            this.cmbCustomer.DataSource = customers;
            this.cmbCustomer.DisplayMember = "Name";
            this.cmbCustomer.ValueMember = "Id";
        }

        public void SetVehicleSource(List<VehicleDto> vehicle)
        {
            this.cmbVehicleType.DataSource = vehicle;
            this.cmbVehicleType.DisplayMember = "VehicleType";
            this.cmbVehicleType.ValueMember = "Id";
        }

        public void SetVehicleRegistrationSource(List<VehicleDetailDto> vehicleDetail)
        {
            this.cmbRegistration.DataSource = vehicleDetail;
            this.cmbRegistration.DisplayMember = "RegistrationNumber";
            this.cmbRegistration.ValueMember = "Id";
        }

        public VehicleDto GetSelectedVehicle()
        {
            if (cmbVehicleType.SelectedIndex == -1) return null;

            return cmbVehicleType.SelectedItem as VehicleDto;
        }

        public void SetItemSource(List<ItemMasterDto> items)
        {
            if (items == null) return;

            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(items.Select(x => $"{x.ItemName} ({x.Id})").ToArray());
            this.txtItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.txtItemName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.txtItemName.AutoCompleteCustomSource = collection;
        }

        public void SetPickupLocation(List<string> locations)
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(locations.ToArray());
            this.txtPickupLocation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.txtPickupLocation.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.txtPickupLocation.AutoCompleteCustomSource = collection;
        }

        public void SetDropLocation(List<string> locations)
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(locations.ToArray());
            this.txtDropLocation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.txtDropLocation.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.txtDropLocation.AutoCompleteCustomSource = collection;
        }

        private void frmRental_Load(object sender, EventArgs e)
        {
            this._presenter.LoadCustomer();
            this._presenter.LoadDriver();
            this._presenter.LoadVehicle();
            this._presenter.LoadItem();
            this._presenter.LoadLocation();
            //this._presenter.LoadVoucherDetail();
            //this._presenter.SetVoucherNo();

            if (this._mode == ActionMode.New)
            {
                this.ClearUI();
            }
        }

        private void cmbVehicleType_Leave(object sender, EventArgs e)
        {
            //logging default configuration
            var customerId = Convert.ToInt32(cmbCustomer.SelectedValue);
            var vehicleId = Convert.ToInt32(cmbVehicleType.SelectedValue);

            //this._presenter.LoadItem(customerId, vehicleId);
            //end

            if (sender.Equals(cmbVehicleType) || sender.Equals(cmbCustomer))
            {
                this._presenter.SetCustomerVehicleDetail();
            }
            else if (sender.Equals(txtItemName))
            {
                int openBrecIndex = txtItemName.Text.LastIndexOf("(");
                string strId = txtItemName.Text.Substring(openBrecIndex + 1).Replace(")", string.Empty);

                int id = 0;
                int.TryParse(strId, out id);
                this._presenter.ShowRateConfiguration(id);
            }
            else if (sender.Equals(dtpFromDate) || sender.Equals(dateTimePicker1))
            {
                int totalDays = (int)dateTimePicker1.Value.Date.Subtract(dtpFromDate.Value.Date).TotalDays + 1;

                if (totalDays == 0)
                {
                    totalDays = 1;
                }
                else if (totalDays < 0)
                {
                    dtpFromDate.Focus();
                    return;
                }

                txtTotalDays.Text = totalDays.ToString();

                this.calculateAmount(totalDays);
            }
            else if (sender.Equals(txtTotalDays))
            {
                int.TryParse(txtTotalDays.Text, out var totalDays);
                this.calculateAmount(totalDays);
            }
            else if (sender.Equals(txtRate))
            {
                double.TryParse(txtQuantity.Text, out var quantity);
                double.TryParse(txtRate.Text, out var rate);
                int.TryParse(txtTotalDays.Text, out var totalDays);
                int.TryParse(Convert.ToString(txtInterval.Tag), out var interval);
                txtAmount.Text =  calculateAmountForItem(quantity, rate, totalDays, interval).ToString();
            }

        }

        private double calculateAmountForItem(double quantity, double rate, int totalDays, int interval)
        {
            if (interval > 0)
            {
                int multiplier = totalDays / interval;
                if (multiplier == 0)
                    multiplier = 1;

                return (quantity * rate * multiplier);
            }
            else
            {
                return (quantity * rate);
            }
        }

        private double getCalculateAmountforItem(double quantity, double rate, int totalDays, int interval)
        {
            if (interval > 0)
            {
                int multiplier = totalDays / interval;
                if (multiplier == 0)
                    multiplier = 1;

                return (quantity * rate * multiplier);
            }
            else
            {
                return (quantity * rate);
            }
        }

        private void calculateAmount(int totalDays)
        {
            DataTable table = this.dgvData.DataSource as DataTable;

            if (table==null || 
                table.Rows.Count == 0)
                return;
            
            foreach (DataRow row in table.Rows)
            {
                VoucherDetailDto detailDto = this._detailGridFomatter.GetObject(row);

                detailDto.Amount = getCalculateAmountforItem(
                    detailDto.Quantity, 
                    detailDto.Rate, 
                    totalDays, 
                    detailDto.Interval);

                detailDto.Action = ActionMode.Edit;

                this._detailGridFomatter.AddRow(detailDto, row);

            }
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        public void SetDriverSource(List<DriverDto> drivers)
        {
            this.cmbDriver.DataSource = drivers;
            this.cmbDriver.DisplayMember = "DriverName";
            this.cmbDriver.ValueMember = "Id";
        }

        public List<VoucherDetailDto> GetDetails()
        {
            DataTable table = this.dgvData.DataSource as DataTable;

            List<VoucherDetailDto> details = new List<VoucherDetailDto>();

            foreach (DataRow dr in table.Rows)
            {
                VoucherDetailDto detailDto = this._detailGridFomatter.GetObject(dr);

                details.Add(detailDto);
            }

            return details;
        }

        public void SetDetails(List<VoucherDetailDto> details)
        {
            throw new NotImplementedException();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            VoucherDetailDto voucherDetail = new VoucherDetailDto();

            #region GetItemId

            int openBrecIndex = txtItemName.Text.LastIndexOf("(");
            voucherDetail.ItemName = txtItemName.Text.Substring(0, openBrecIndex - 1);
            string strId = txtItemName.Text.Substring(openBrecIndex + 1).Replace(")", string.Empty);

            int id = 0;
            if (int.TryParse(strId, out id))
            {
                voucherDetail.ItemId = id;
            }

            #endregion
            double.TryParse(txtQuantity.Text, out var quantity);
            double.TryParse(txtRate.Text, out var rate);
            int.TryParse(txtTotalDays.Text, out var totalDays);
            //int interval = Convert.ToInt32(txtInterval.Tag);
            //int multiplier = 0;

            //if (interval == 0)
            //{
            //    multiplier = 1;
            //}
            //else
            //{
            //    multiplier = totalDays / interval;
            //    if (multiplier < 1) multiplier = 1;
            //}

            voucherDetail.Quantity = quantity;
            voucherDetail.Unit = txtUnit.Text;
            voucherDetail.Rate = rate;
            //voucherDetail.Amount = rate * quantity * multiplier;
            double.TryParse(txtAmount.Text, out var amt);
            voucherDetail.Amount = amt;
            voucherDetail.Interval = Convert.ToInt32(txtInterval.Tag);
            voucherDetail.IntervalName = txtInterval.Text;
            voucherDetail.Id = Convert.ToInt32(txtItemName.Tag);
            voucherDetail.ItemDescription = txtItemDescription.Text;

            if (Convert.ToInt32(txtItemName.Tag) == 0)
            {
                voucherDetail.Action = ActionMode.New;
                this._presenter.AddDetail(voucherDetail);
            }
            else
            {
                voucherDetail.Action = ActionMode.Edit;
                this._presenter.UpdateDetail(voucherDetail);
            }
            //this._presenter.SaveAndNew();
        }

        public int GetVoucherId()
        {
            int.TryParse(txtVoucherId.Text, out var result);
            return result;
        }

        public void SetDetailSource(DataTable detailTable, VoucherDetailGridFormatter detailGridFormatter)
        {
            this.dgvData.DataSource = detailTable;
            detailGridFormatter.ResizeColumn(this.dgvData);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.CloseUI();
        }

        public CustomerDto GetSelectedCustomer()
        {
            if (cmbCustomer.SelectedIndex == -1) return null;

            return (cmbCustomer.SelectedItem as CustomerDto);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._presenter.SaveAndNew();
        }

        public void SetVoucherNo(string voucherNo)
        {
            throw new NotImplementedException();
        }

        public void SetDetailGridFormatter(VoucherDetailGridFormatter detailGridFormatter)
        {
            this._detailGridFomatter = detailGridFormatter;
        }

        private void cmbVehicleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._presenter.LoadVehicleDetail();
        }

        public DataRow SelectedDetailItem()
        {
            DataRowView rowView = this.dgvData.SelectedRows[0].DataBoundItem as DataRowView;
            return rowView.Row;
        }

        public void SetDetailDto(VoucherDetailDto detailDto)
        {
            txtItemName.Text = $"{detailDto.ItemName} ({detailDto.ItemId})";
            txtItemDescription.Text = detailDto.ItemDescription;
            txtQuantity.Text = detailDto.Quantity.ToString();
            txtRate.Text = detailDto.Rate.ToString();
            txtUnit.Text = detailDto.Unit.ToString();
            txtItemName.Tag = detailDto.Id;
            txtAmount.Text = detailDto.Amount.ToString();
            txtInterval.Text = detailDto.IntervalName;
            txtInterval.Tag = detailDto.Interval;
            txtQuantity.ReadOnly = (detailDto.Interval > 0);
        }

        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this._presenter.OpenItemForEdit();
        }

        public void ShowItemInfo(RateInfoDto rateInfo)
        {
            txtQuantity.Text = rateInfo.Quantity.ToString();
            txtUnit.Text = rateInfo.Unit;
            txtInterval.Text = rateInfo.IntervalName;
            txtInterval.Tag = rateInfo.Interval;
            txtQuantity.ReadOnly = (rateInfo.Interval > 0);
        }

        public int GetTotalDays()
        {
            int.TryParse(txtTotalDays.Text, out var totalDays);
            return totalDays;
        }

        private void EnableWorkFromTo()
        {
            maskStartFrom.Enabled = true;
            maskEndFrom.Enabled = true;
        }

        private void DisableWorkFromTo()
        {
            maskStartFrom.Enabled = false;
            maskEndFrom.Enabled = false;
        }

        private void radKM_CheckedChanged(object sender, EventArgs e)
        {
            CustomReadioButton senderRadioButton = sender as CustomReadioButton;
            BillingWorkType selectedWorkType = (BillingWorkType)Enum.Parse(typeof(BillingWorkType), Convert.ToString(senderRadioButton.Tag));

            switch (selectedWorkType)
            {
                case BillingWorkType.KM:
                    this.EnableWorkFromTo();
                    maskEndFrom.Mask = "#####";
                    maskStartFrom.Mask = "#####";
                    break;
                case BillingWorkType.TIME:
                    this.EnableWorkFromTo();
                    maskEndFrom.Mask = "00:00";
                    maskStartFrom.Mask = "00:00";
                    break;
                case BillingWorkType.NONE:
                    this.DisableWorkFromTo();
                    break;
            }
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            if (MessageBox.Show($"Are you sure you want to delete selected VoucherItem?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            if (this._presenter.DeleteDetail())
                this.dgvData.Rows.Remove(this.dgvData.SelectedRows[0]);
        }
    }
}
