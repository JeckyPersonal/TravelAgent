using Invoice.Test.Model.Company;
using Invoice.UI.CustomControl;
using Invoice.UI.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Invoice.UI.Item
{
    internal partial class frmItem : TitledForm, IItemView
    {

        private readonly ItemPresenter _presenter;
        private ItemMasterDto _dto;
        private ActionMode _action;

        public frmItem(ItemPresenter presenter)
        {
            InitializeComponent();
            this._presenter = presenter;
        }

        public void ClearUI()
        {
            txtCompanyName.Clear();
            txtDescription.Clear();
            txtId.Clear();
            txtItemQuantity.Clear();
            txtRate.Clear();
            cmbUnit.SelectedIndex = -1;
            cmbInterval.SelectedIndex = -1;
            cmbType.SelectedIndex = -1;
            radNoGST.Checked = true;
            radForVoucher.Checked = true;
        }

        public DialogResult ShowMessage()
        {
            return MessageBox.Show(
                "Iteam detail save successfully.",
                "Iteam Detail",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
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
            this._dto.ItemName = txtCompanyName.Text;
            this._dto.ItemDescription = txtDescription.Text;
            int.TryParse(txtId.Text, out var id);
            this._dto.Id = id;

            double rate = 0;
            Double.TryParse(txtRate.Text, out rate);

            this._dto.Rate = rate;
            this._dto.AppliedGST = radApplyGST.Checked;
            this._dto.SourceVoucher = radForVoucher.Checked;
            this._dto.SourceInvoice = radForInvoice.Checked;
            this._dto.Quantity = Convert.ToInt32(txtItemQuantity.Text);
            this._dto.Unit = cmbUnit.Text;
            Enum.TryParse<ItemType>(cmbType.SelectedItem.ToString(),true, out var itemType);
            this._dto.ItemCategory= itemType;

            ItemIntervalDto intervalDto = this.cmbInterval.SelectedItem as ItemIntervalDto;
            this._dto.IntervalId = intervalDto.Id;
            this._dto.IntervalName = intervalDto.IntervalName;

            return this._dto;
        }

        public ActionMode GetMode()
        {
            return this._action;
        }

        public void SetDto(object dto)
        {
            ItemMasterDto itemDto = dto as ItemMasterDto;

            this._dto = itemDto;

            if (itemDto == null || itemDto.Id == 0)
            {
                this._action = ActionMode.New;
                return;
            }

            this.txtCompanyName.Text = this._dto.ItemName;
            this.txtDescription.Text = this._dto.ItemDescription;
            this.txtId.Text = this._dto.Id.ToString();
            this.txtRate.Text = this._dto.Rate.ToString();
            this.radApplyGST.Checked = this._dto.AppliedGST;
            this.radForVoucher.Checked= this._dto.SourceVoucher;
            this.radForInvoice.Checked = this._dto.SourceInvoice;
            this.txtItemQuantity.Text = this._dto.Quantity.ToString();
            this.cmbUnit.Text = this._dto.Unit;
            this.cmbInterval.Text = this._dto.IntervalName;
            this.cmbType.Text = this._dto.ItemCategory.ToString();

            this._action = ActionMode.Edit;
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

        private void txtCompanyName_Leave(object sender, System.EventArgs e)
        {
            if (sender.Equals(txtCompanyName))
            {
                this._dto.ItemName = txtCompanyName.Text;
            }
            if (sender.Equals(txtDescription))
            {
                this._dto.ItemDescription = txtDescription.Text;
            }
            else if (sender.Equals(txtId))
            {
                this._dto.Id = Convert.ToInt32(txtId.Text);
            }
            else if (sender.Equals(txtRate))
            {
                double rate = 0;
                Double.TryParse(txtRate.Text, out rate);
                this._dto.Rate = rate;
            }
            else if (sender.Equals(radApplyGST))
            {
                this._dto.AppliedGST = radApplyGST.Checked;
            }
            else if (sender.Equals(radForVoucher))
            {
                this._dto.SourceVoucher = radForVoucher.Checked;
            }
            else if (sender.Equals(radForInvoice))
            {
                this._dto.SourceInvoice = radForInvoice.Checked;
            }
            else if (sender.Equals(txtItemQuantity))
            {
                int.TryParse(txtItemQuantity.Text, out var quantity);
                this._dto.Quantity = quantity;
            }
            else if (sender.Equals(cmbUnit))
            {
                this._dto.Unit = cmbUnit.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Focus();
            this._presenter.SaveAndNew();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this._presenter.Close();
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
            this._presenter.LoadIntervals();
            this._presenter.LoadType();
            this.cmbInterval.Text = this._dto.IntervalName;
            this.cmbType.Text = this._dto.ItemCategory.ToString();
        }

        public void SetIntervalSource(List<ItemIntervalDto> intervals)
        {
            this.cmbInterval.DataSource = intervals;
            this.cmbInterval.DisplayMember = "IntervalName";
            this.cmbInterval.ValueMember = "Id";
           
        }

        public void SetType(List<string> types)
        {
            this.cmbType.DataSource = types;
            this.cmbType.DisplayMember = "Value";
        }
    }
}
