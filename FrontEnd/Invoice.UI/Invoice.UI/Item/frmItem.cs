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
            txtId.Clear();
            txtItemQuantity.Clear();
            txtRate.Clear();
            cmbUnit.SelectedIndex = -1;
            cmbInterval.SelectedIndex = -1;
            chkBoxAppliedGST.Checked = false;
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
            int.TryParse(txtId.Text, out var id);
            this._dto.Id = id;

            double rate = 0;
            Double.TryParse(txtRate.Text, out rate);

            this._dto.Rate = rate;
            this._dto.AppliedGST = chkBoxAppliedGST.Checked;
            this._dto.Quantity = Convert.ToInt32(txtItemQuantity.Text);
            this._dto.Unit = cmbUnit.Text;

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
            this.txtId.Text = this._dto.Id.ToString();
            this.txtRate.Text = this._dto.Rate.ToString();
            this.chkBoxAppliedGST.Checked = this._dto.AppliedGST;
            this.txtItemQuantity.Text = this._dto.Quantity.ToString();
            this.cmbUnit.Text = this._dto.Unit;
            this.cmbInterval.Text = this._dto.IntervalName;

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
            else if (sender.Equals(chkBoxAppliedGST))
            {
                this._dto.AppliedGST = chkBoxAppliedGST.Checked;
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

        private Color CHECKED_BACKGROUND_COLOUR = Color.FromArgb(255, 255, 192);
        private Color UNCHECKED_BACKGROUND_COLOR = Color.Olive;
        private Color CHECKED_FOR_COLOR = Color.FromArgb(128, 64, 0);
        private Color UNCHECKED_FOR_COLOR = Color.White;

        private void chkBoxAppliedGST_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxAppliedGST.Checked)
            {
                chkBoxAppliedGST.BackColor = CHECKED_BACKGROUND_COLOUR;
                chkBoxAppliedGST.ForeColor = CHECKED_FOR_COLOR;
            }
            else
            {
                chkBoxAppliedGST.BackColor = UNCHECKED_BACKGROUND_COLOR;
                chkBoxAppliedGST.ForeColor = UNCHECKED_FOR_COLOR;
            }
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
            this._presenter.LoadIntervals();
            this.cmbInterval.Text = this._dto.IntervalName;
            if (this._dto.IntervalId != null) { 
                this.cmbInterval.SelectedValue = this._dto.IntervalId;
            }
            this.cmbInterval.SelectedIndex = 0;
        }

        public void SetIntervalSource(List<ItemIntervalDto> intervals)
        {
            this.cmbInterval.DataSource = intervals;
            this.cmbInterval.DisplayMember = "IntervalName";
            this.cmbInterval.ValueMember = "Id";
           
        }
    }
}
