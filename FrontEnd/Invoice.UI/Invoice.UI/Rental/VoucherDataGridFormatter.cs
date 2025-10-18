using Invoice.UI.DTO;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Data;
using System.Windows.Forms;

namespace Invoice.UI.Rental
{
    internal class VoucherDataGridFormatter : IDataGridFormatter, IRowAdder<VoucherMasterDto>
    {

        public const string COLUMN_NAME_ID = "Id";
        public const string COLUMN_NAME_FROM_DATE = "From Date";
        public const string COLUMN_NAME_TO_DATE = "To Date";
        public const string COLUMN_NAME_CUSTOMER_ID = "Customer Id";
        public const string COLUMN_NAME_CUSTOMER_NAME = "Customer Name";
        public const string COLUMN_NAME_VEHICLE_ID = "Vehicle Id";
        public const string COLUMN_NAME_VEHICLE_NAME = "Vehicle Name";
        public const string COLUMN_NAME_REGISTRATION_ID = "Registration Id";
        public const string COLUMN_NAME_REGISTRATION_NO = "Registration No";
        public const string COLUMN_NAME_PICKUP_LOCATION = "Pickup Location";
        public const string COLUMN_NAME_DROP_LOCATION = "Drop Location";
        public const string COLUMN_NAME_VOUCHER_NO = "Voucher No";
        public const string COLUMN_NAME_VOUCHER_DATE = "Voucher Date";
        public const string COLUMN_NAME_DRIVER_ID = "Driver Id";
        public const string COLUMN_NAME_DRIVER_NAME = "Driver Name";

        public void AddColumns(DataTable table)
        {
            table.Columns.Add(COLUMN_NAME_ID);
            table.Columns.Add(COLUMN_NAME_VOUCHER_NO);
            table.Columns.Add(COLUMN_NAME_VOUCHER_DATE);
            table.Columns.Add(COLUMN_NAME_FROM_DATE);
            table.Columns.Add(COLUMN_NAME_TO_DATE);
            table.Columns.Add(COLUMN_NAME_CUSTOMER_ID);
            table.Columns.Add(COLUMN_NAME_CUSTOMER_NAME);
            table.Columns.Add(COLUMN_NAME_VEHICLE_ID);
            table.Columns.Add(COLUMN_NAME_VEHICLE_NAME);
            table.Columns.Add(COLUMN_NAME_DRIVER_ID);
            table.Columns.Add(COLUMN_NAME_DRIVER_NAME);
            table.Columns.Add(COLUMN_NAME_REGISTRATION_ID);
            table.Columns.Add(COLUMN_NAME_REGISTRATION_NO);
            table.Columns.Add(COLUMN_NAME_PICKUP_LOCATION);
            table.Columns.Add(COLUMN_NAME_DROP_LOCATION);
        }

        public void AddRow(VoucherMasterDto entity, DataRow row)
        {
            row[COLUMN_NAME_ID] = entity.Id;
            row[COLUMN_NAME_VOUCHER_NO] = entity.VoucherNo;
            row[COLUMN_NAME_VOUCHER_DATE] = entity.VoucherDate;
            row[COLUMN_NAME_FROM_DATE] = entity.FromDate;
            row[COLUMN_NAME_TO_DATE] = entity.ToDate;
            row[COLUMN_NAME_CUSTOMER_ID] = entity.CustomerId;
            row[COLUMN_NAME_CUSTOMER_NAME] = entity.CustomerName;
            row[COLUMN_NAME_DRIVER_ID] = entity.VehicleId;
            row[COLUMN_NAME_DRIVER_NAME] = entity.VehicleType;
            row[COLUMN_NAME_VEHICLE_ID] = entity.VehicleId;
            row[COLUMN_NAME_VEHICLE_NAME] = entity.VehicleType;
            row[COLUMN_NAME_REGISTRATION_ID] = entity.RegistrationId;
            row[COLUMN_NAME_REGISTRATION_NO] = entity.RegistrationNo;
            row[COLUMN_NAME_PICKUP_LOCATION] = entity.PickupLocation;
            row[COLUMN_NAME_DROP_LOCATION] = entity.DropLocation;
        }

        public VoucherMasterDto GetObject(DataRow row)
        {
            VoucherMasterDto masterDto = new VoucherMasterDto();

            masterDto.Id = Convert.ToInt32(row[COLUMN_NAME_ID]);
            masterDto.VoucherNo = Convert.ToString(row[COLUMN_NAME_VOUCHER_NO]);
            masterDto.VoucherDate = Convert.ToDateTime(row[COLUMN_NAME_VOUCHER_DATE]);
            masterDto.FromDate = Convert.ToDateTime(row[COLUMN_NAME_FROM_DATE]);
            masterDto.ToDate = Convert.ToDateTime(row[COLUMN_NAME_TO_DATE]);
            masterDto.CustomerId = Convert.ToInt32(row[COLUMN_NAME_CUSTOMER_ID]);
            masterDto.CustomerName = Convert.ToString(row[COLUMN_NAME_CUSTOMER_NAME]);
            masterDto.VehicleId =  Convert.ToInt32(row[COLUMN_NAME_DRIVER_ID]);
            masterDto.VehicleType = Convert.ToString( row[COLUMN_NAME_DRIVER_NAME]);
            masterDto.VehicleId = Convert.ToInt32(row[COLUMN_NAME_VEHICLE_ID]);
            masterDto.VehicleType = Convert.ToString(row[COLUMN_NAME_VEHICLE_NAME]);
            masterDto.RegistrationId = Convert.ToInt32(row[COLUMN_NAME_REGISTRATION_ID]);
            masterDto.RegistrationNo = Convert.ToString(row[COLUMN_NAME_REGISTRATION_NO]);
            masterDto.PickupLocation = Convert.ToString(row[COLUMN_NAME_PICKUP_LOCATION]);
            masterDto.DropLocation = Convert.ToString(row[COLUMN_NAME_DROP_LOCATION]);

            return masterDto;
        }

        public void ResizeColumn(DataGridView dgv)
        {
            dgv.Columns[COLUMN_NAME_ID].Width = 50;
            dgv.Columns[COLUMN_NAME_VOUCHER_NO].Width = 100;
            dgv.Columns[COLUMN_NAME_VOUCHER_DATE].Width = 150;
            dgv.Columns[COLUMN_NAME_FROM_DATE].Width = 150;
            dgv.Columns[COLUMN_NAME_TO_DATE].Width = 150;
            dgv.Columns[COLUMN_NAME_CUSTOMER_ID].Visible = false;
            dgv.Columns[COLUMN_NAME_CUSTOMER_NAME].Width = 300;
            dgv.Columns[COLUMN_NAME_VEHICLE_ID].Visible = false;
            dgv.Columns[COLUMN_NAME_VEHICLE_NAME].Width = 200;
            dgv.Columns[COLUMN_NAME_REGISTRATION_ID].Visible = false;
            dgv.Columns[COLUMN_NAME_REGISTRATION_NO].Width = 200;
            dgv.Columns[COLUMN_NAME_PICKUP_LOCATION].Width = 300;
            dgv.Columns[COLUMN_NAME_DROP_LOCATION].Width = 300;
            dgv.Columns[COLUMN_NAME_DRIVER_ID].Visible = false;
            dgv.Columns[COLUMN_NAME_DRIVER_NAME].Width = 200;
        }
    }
}
