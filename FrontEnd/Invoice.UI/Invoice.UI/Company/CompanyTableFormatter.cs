using Invoice.DTO;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Invoice.UI.Company
{
    internal class CompanyTableFormatter : IDataGridFormatter, IRowAdder<CompanyDto>
    {
        private const string COLUMN_NAME_ID = "Id";
        private const string COLUMN_NAME_NAME = "Name";
        private const string COLUMN_NAME_ADDRESS1 = "Address1";
        private const string COLUMN_NAME_ADDRESS2 = "Address2";
        private const string COLUMN_NAME_ADDRESS3 = "Address3";
        private const string COLUMN_NAME_CITY = "City";
        private const string COLUMN_NAME_STATE = "State";
        private const string COLUMN_NAME_ZIP = "Zip";
        private const string COLUMN_NAME_COUNTRY = "Country";
        private const string COLUMN_NAME_GST = "GST";
        private const string COLUMN_NAME_LUT = "LUT";
        private const string COLUMN_NAME_PAN = "PAN";
        private const string COLUMN_NAME_PHONE = "Phone";

        public void AddColumns(DataTable table)
        {
            table.Columns.Add(new DataColumn(COLUMN_NAME_ID));
            table.Columns.Add(new DataColumn(COLUMN_NAME_NAME));
            table.Columns.Add(new DataColumn(COLUMN_NAME_ADDRESS1));
            table.Columns.Add(new DataColumn(COLUMN_NAME_ADDRESS2));
            table.Columns.Add(new DataColumn(COLUMN_NAME_ADDRESS3));
            table.Columns.Add(new DataColumn(COLUMN_NAME_CITY));
            table.Columns.Add(new DataColumn(COLUMN_NAME_STATE));
            table.Columns.Add(new DataColumn(COLUMN_NAME_ZIP));
            table.Columns.Add(new DataColumn(COLUMN_NAME_COUNTRY));
            table.Columns.Add(new DataColumn(COLUMN_NAME_PHONE));
            table.Columns.Add(new DataColumn(COLUMN_NAME_GST));
            table.Columns.Add(new DataColumn(COLUMN_NAME_LUT));
            table.Columns.Add(new DataColumn(COLUMN_NAME_PAN));
        }

        public void AddRow(CompanyDto companyDto, DataRow row)
        {
            row[COLUMN_NAME_ID] = companyDto.Id;
            row[COLUMN_NAME_NAME] = companyDto.Name;
            row[COLUMN_NAME_ADDRESS1] = companyDto.Address1;
            row[COLUMN_NAME_ADDRESS2] = companyDto.Address2;
            row[COLUMN_NAME_ADDRESS3] = companyDto.Address3;
            row[COLUMN_NAME_CITY] = companyDto.City;
            row[COLUMN_NAME_STATE] = companyDto.State;
            row[COLUMN_NAME_ZIP] = companyDto.Zip;
            row[COLUMN_NAME_COUNTRY] = companyDto.Country;
            row[COLUMN_NAME_PHONE] = companyDto.PhoneNumber;
            row[COLUMN_NAME_GST] = companyDto.GSTNo;
            row[COLUMN_NAME_LUT] = companyDto.LUTNo;
            row[COLUMN_NAME_PAN] = companyDto.PANNo;
        }

        public void AppendRows(EntityLoader<CompanyDto> entityLoader, DataTable table)
        {
            throw new NotImplementedException();
        }

        public void BuildTable(EntityLoader<CompanyDto> entityLoader, DataTable _table)
        {
            if (_table != null)
                _table.Rows.Clear();

            _table.Columns.Clear();

            this.AddColumns(_table);

            List<CompanyDto> companies = entityLoader.GetEntities();

            foreach (CompanyDto companyDto in companies)
            {
                DataRow row = _table.NewRow();

                this.AddRow(companyDto, row);

                _table.Rows.Add(row);
            }
        }

        public CompanyDto GetObject(DataRow row)
        {
            CompanyDto companyDto = new CompanyDto();

            companyDto.Id = Convert.ToInt32(row[COLUMN_NAME_ID]);
            companyDto.Name = Convert.ToString(row[COLUMN_NAME_NAME]);
            companyDto.Address1 = Convert.ToString(row[COLUMN_NAME_ADDRESS1]);
            companyDto.Address2 = Convert.ToString(row[COLUMN_NAME_ADDRESS2]);
            companyDto.Address3 = Convert.ToString(row[COLUMN_NAME_ADDRESS3]);
            companyDto.City = Convert.ToString(row[COLUMN_NAME_CITY]);
            companyDto.State = Convert.ToString(row[COLUMN_NAME_STATE]);
            companyDto.Zip = Convert.ToString(row[COLUMN_NAME_ZIP]);
            companyDto.Country = Convert.ToString(row[COLUMN_NAME_COUNTRY]);
            companyDto.PhoneNumber = Convert.ToString(row[COLUMN_NAME_PHONE]);
            companyDto.GSTNo= Convert.ToString(row[COLUMN_NAME_GST]);
            companyDto.LUTNo = Convert.ToString(row[COLUMN_NAME_LUT]);
            companyDto.PANNo= Convert.ToString(row[COLUMN_NAME_PAN]);

            return companyDto;
        }

        public void ResizeColumn(DataGridView dgv)
        {
            dgv.Columns[COLUMN_NAME_ID].Width = 50;
            dgv.Columns[COLUMN_NAME_NAME].Width = 200;
            dgv.Columns[COLUMN_NAME_ADDRESS1].Width = 250;
            dgv.Columns[COLUMN_NAME_ADDRESS2].Width = 250;
            dgv.Columns[COLUMN_NAME_ADDRESS3].Width = 250;
            dgv.Columns[COLUMN_NAME_CITY].Width = 150;
            dgv.Columns[COLUMN_NAME_STATE].Width = 150;
            dgv.Columns[COLUMN_NAME_COUNTRY].Width = 100;
            dgv.Columns[COLUMN_NAME_GST].Width = 150;
            dgv.Columns[COLUMN_NAME_LUT].Width = 150;
            dgv.Columns[COLUMN_NAME_PAN].Width = 150;
            dgv.Columns[COLUMN_NAME_PHONE].Width = 150;
        }
    }
}
