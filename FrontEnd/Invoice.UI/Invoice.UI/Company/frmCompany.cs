using Invoice.DTO;
using Invoice.Test.Model.Company;
using Invoice.UI.Company;
using Invoice.UI.CustomControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Windows.Forms;

namespace Invoice.UI
{
    public partial class frmCompany : Form, ICompanyView
    {


        private CompanyPresenter _presenter;
        private CompanyDto _dto;
        private ActionMode _actionMode;
        private bool _isError = false;

        public frmCompany(CompanyPresenter presenter) : base()
        {
            InitializeComponent();
            this._presenter = presenter;
            this._presenter.SetView(this);
        }

        public void ClearUI()
        {
            txtAddress1.Clear();
            txtAddress2.Clear();
            txtAddress3.Clear();
            txtCity.Clear();
            txtState.Clear();
            txtCompanyName.Clear();
            txtCountry.Clear();
            txtId.Clear();
            txtPan.Clear();
            txtGST.Clear();
            txtCountry.Clear();
            txtPhone.Clear();
            txtZipCode.Clear();
        }

        public CompanyDto DTO { get { return _dto; } }

        public DialogResult CloseUI()
        {
            DialogResult result = this.DialogResult;
            this.Close();
            return result;
        }

        public void SaveUI()
        {
            throw new NotImplementedException();
        }

        public void SetDto(object dto)
        {
            this._dto = (CompanyDto)dto;

            if (this._dto.Id == 0)
            {
                this._actionMode = ActionMode.New;
                return;
            }

            txtAddress1.Text = this._dto.Address1;
            txtAddress2.Text = this._dto.Address2;
            txtAddress3.Text = this._dto.Address3;

            txtCity.Text = this._dto.City;
            txtState.Text = this._dto.State;
            txtCountry.Text = this._dto.Country;
            txtPhone.Text = this._dto.PhoneNumber;
            txtZipCode.Text = this._dto.Zip;

            txtId.Text = this._dto.Id.ToString();
            txtCompanyName.Text = this._dto.Name;

            txtGST.Text = this._dto.GSTNo;
            txtPan.Text = this._dto.PANNo;

            this._actionMode = ActionMode.Edit;
        }

        public void SetDto<T>(T dto)
        {
            throw new NotImplementedException();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this._isError = false;
            this._presenter.SaveAndNew();
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            this._presenter.LoadUI();
        }

        private void txtPan_Leave(object sender, EventArgs e)
        {
            if (sender.Equals(txtId))
            {
                if (txtId.Text != String.Empty)
                {
                    this._dto.Id = Convert.ToInt32(txtId.Text);
                }
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
            else if (sender.Equals(txtPhone))
            {
                this._dto.PhoneNumber = txtPhone.Text;
            }
            else if (sender.Equals(txtGST))
            {
                this._dto.GSTNo = txtGST.Text;
            }
            else if (sender.Equals(txtPan))
            {
                this._dto.PANNo = txtPan.Text;
            }
            else if (sender.Equals(txtZipCode))
            {
                this._dto.Zip = txtZipCode.Text;
            }
        }

        public void ShowError(ValidationErrorResponse errorResponse)
        {
            //this.SuspendLayout();
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

            //this.ResumeLayout();
        }

        private void heading1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void heading1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("clicked");
        }

        public ActionMode GetMode()
        {
            return this._actionMode;
        }

        public object GetDto()
        {
            throw new NotImplementedException();
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            this._presenter.SaveAndNew();
            if (!_isError) { 
                this.Close();
            }
        }
    }
}
