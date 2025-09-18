
using Invoice.UI.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace Invoice.UI.Bank.BankDetail
{
    public class BankDetailPresenter : BasePresenter
    {
        private IBankDetailView _bankDetailView;
        private BankDetailRestClient _bankDetailRestClient;

        public BankDetailPresenter(BankDetailRestClient bankDetailRestClient)
        {
            this._bankDetailRestClient = bankDetailRestClient;
        }

        public override void Close()
        {
            this._bankDetailView.CloseUI();
        }

        public override void SaveAndClose()
        {
            this.saveBankDetail();
            this._bankDetailView.CloseUI();
        }

        public override void SaveAndNew()
        {
            BankDetailDto savedDto = this.saveBankDetail();
            this.LoadAllDetail(savedDto.BankId);
            this._bankDetailView.ClearUI();
        }

        private BankDetailDto saveBankDetail()
        {
            BankDetailDto bankDetailDto = this._bankDetailView.GetDto() as BankDetailDto;

            if (this._bankDetailView.GetMode() == ActionMode.New)
            {
                return this._bankDetailRestClient.Add(bankDetailDto);
            }
            else
            {
                return this._bankDetailRestClient.Update(bankDetailDto);
            }
        }

        protected override object BuidDtoForEdit(int id)
        {
            return this._bankDetailRestClient.Get(id);
        }

        protected override object BuildDto()
        {
            return new BankDetailDto();
        }

        public void SetView(IBankDetailView view)
        {
            base.SetView(view);
            this._bankDetailView = view;
        }

        internal void LoadAllDetail(int bankId)
        {
            DataTable table = new DataTable();

            table.Columns.Add(new DataColumn("Id"));
            table.Columns.Add(new DataColumn("AccountNumber"));
            table.Columns.Add(new DataColumn("IFSCCode"));

            List<BankDetailDto> list = this._bankDetailRestClient.GetByBank(bankId);

            foreach(BankDetailDto bankDetailDto in list)
            {
                DataRow newRow = table.NewRow();

                newRow["Id"] = bankDetailDto.Id;
                newRow["AccountNumber"] = bankDetailDto.AccountNumber;
                newRow["IFSCCode"] = bankDetailDto.IFSCCode;

                table.Rows.Add(newRow);
            }

            this._bankDetailView.LoadDetail(table);
        }

        internal void OpenDetailForEdit(DataRow row)
        {
            throw new NotImplementedException();
        }
    }
}
