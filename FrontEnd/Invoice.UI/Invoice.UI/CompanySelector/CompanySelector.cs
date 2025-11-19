using Invoice.DTO;
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

namespace Invoice.UI.CompanySelector
{
    internal partial class CompanySelector : TitledForm, ICompanySelectorView
    {
        private readonly CompanySelectorPresenter _presenter;

        public CompanySelector() : base() 
        {
            InitializeComponent();
            this.heading1.Title = "Company Selector";
            this._presenter = new CompanySelectorPresenter(Company.CompanyRestClient.Instance, FinancialYear.FinancialYearRestClient.Instance);
            this._presenter.SetView(this);
        }

        public void BindDataSource(List<CompanyDto> companies)
        {
            this.cmbCompany.DataSource = companies;
            this.cmbCompany.DisplayMember = "Name";
            this.cmbCompany.ValueMember = "Id";
        }

        private void CompanySelector_Leave(object sender, EventArgs e)
        {

        }

        public DialogResult ShowMessage()
        {
            return showConformMessage("Required data selected", "Company Selector", MessageBoxButtons.OK);
        }

        private DialogResult showConformMessage(string message, string title, MessageBoxButtons buttons) 
        {
            switch (buttons) 
            { 
                case MessageBoxButtons.YesNo: 
                    {
                        return MessageBox.Show(message, title,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button1);

                    }
                case MessageBoxButtons.OK:
                    {
                        return MessageBox.Show(message, title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);

                    }
                default: 
                    {
                        return MessageBox.Show(message, title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                    }
            }
        }

        private void CompanySelector_Load(object sender, EventArgs e)
        {
            this._presenter.ListDownCompany();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

            if (cmbCompany.SelectedIndex == -1) 
            {
                var result = showConformMessage("Click 'Yes' to Create new company.",
                    "Company Selector",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    this._presenter.createCompany();
                    Settings.CompanyId = GetSelectedItem().Id;
                }
            }

            if (cmbCompany.SelectedIndex != -1 && 
                cmbFinancialYear.SelectedIndex == -1) 
            {
                var result = showConformMessage("Financial year for '"+ 
                    (cmbCompany.SelectedItem as CompanyDto).Name +
                    "' not found.Click 'Yes' to Create new Financial Year.",
                    "Company Selector",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes) 
                {
                    Settings.CompanyId = GetSelectedItem().Id;
                    this._presenter.createFinancialYear();
                    this._presenter.ShowFinancialYear();
                }
            }

            if (cmbCompany.SelectedIndex != -1 && 
                cmbFinancialYear.SelectedIndex != -1) 
            {
                this.DialogResult = DialogResult.OK;
                this._presenter.SelectCompany();
            }
        }

        public CompanyDto GetSelectedItem()
        {
            return (CompanyDto)this.cmbCompany.SelectedItem;
        }

        public void ClearUI()
        {
            this.cmbCompany.SelectedItem = -1;
        }

        public DialogResult CloseUI()
        {
            DialogResult result = this.DialogResult;

            this.Close();

            return result;
        }

        public void SetDto(object dto)
        {
            throw new NotImplementedException();
        }

        public void ShowError(ValidationErrorResponse error)
        {
            throw new NotImplementedException();
        }

        public ActionMode GetMode()
        {
            return ActionMode.Select;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public object GetDto()
        {
            throw new NotImplementedException();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

            this._presenter.ShowFinancialYear();
        }

        public void BindFinancialYear(List<FinancialYearDto> financialYears)
        {
            this.cmbFinancialYear.DataSource = financialYears;
            this.cmbFinancialYear.DisplayMember = "Year";
            this.cmbFinancialYear.ValueMember = "Id";
        }

        public CompanyDto GetSelectedCompany()
        {
            return  this.cmbCompany.SelectedItem as CompanyDto;
        }

        public FinancialYearDto GetFinancialYear()
        {
            return this.cmbFinancialYear.SelectedItem as FinancialYearDto;
        }
    }
}
