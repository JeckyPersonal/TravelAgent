using Invoice.UI.DTO;
using Invoice.UI.Exceptions;

namespace Invoice.UI.Bank
{
    public class BankPresenter : BasePresenter
    {
        private BankRestClient _bankRestClient;
        private IBankView _bankView;

        public BankPresenter(BankRestClient bankRestClient)
        {
            _bankRestClient = bankRestClient;
        }

        public override void Close()
        {
            this._bankView.CloseUI();
        }

        public override void SaveAndClose()
        {
            this.saveBank();
            this._bankView.CloseUI();
        }

        public override void SaveAndNew()
        {
            try
            {
                this.saveBank();
                this._bankView.ClearUI();
            }
            catch (ValidationException vex)
            {
                this._bankView.ShowError(vex.Errors);
            }
        }

        private void saveBank()
        {
            BankDto bankDto =  this._bankView.GetDto() as BankDto;
            if (this._bankView.GetMode().Equals(ActionMode.New))
            {
                BankDto savedDto = this._bankRestClient.Add(bankDto);
            }
            else
            {
                BankDto savedDto = this._bankRestClient.Update(bankDto);
            }
        }

        public void SetView(IBankView view)
        {
            base.SetView(view);
            this._bankView = view;
        }

        protected override object BuidDtoForEdit(int id)
        {
            return this._bankRestClient.Get(id);
        }

        protected override object BuildDto()
        {
            return new BankDto();
        }
    }
}
