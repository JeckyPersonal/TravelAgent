using Invoice.UI.DTO;
using System;

namespace Invoice.UI.FinancialYear
{
    internal class FinancialYearPresenter : BasePresenter
    {
        private FinancialYearRestClient _restClient;
        private IFinancialYearView _view;

        public FinancialYearPresenter(FinancialYearRestClient restClient)
        {
            this._restClient = restClient;
        }

        public override void Close()
        {
            this._view.CloseUI();
        }

        public override void SaveAndClose()
        {
            FinancialYearDto dto = this._view.GetDto() as FinancialYearDto;
            this.saveFinancialYear(dto);
            this.Close();
        }

        private FinancialYearDto saveFinancialYear(FinancialYearDto dto)
        {
            if (this._view.GetMode() == ActionMode.New)
            {
                return this._restClient.Add(dto);
            }
            else
            {
                return this._restClient.Update(dto);
            }
        }

        public override void SaveAndNew()
        {
            FinancialYearDto dto = this._view.GetDto() as FinancialYearDto;
            this.saveFinancialYear(dto);
            this._view.ClearUI();
        }

        protected override object BuidDtoForEdit(int id)
        {
            return this._restClient.Get(id);
        }

        protected override object BuildDto()
        {
            return new FinancialYearDto();
        }

        internal void SetView(IFinancialYearView view)
        {
            this._view = view;
            base.SetView(view);
        }
    }
}