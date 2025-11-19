using Invoice.UI.DTO;
using Invoice.UI.Exceptions;
using System.Windows.Forms;

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
            }
            catch (ValidationException vex)
            {
                this._bankView.ShowError(vex.Errors);
            }
        }

        private void saveBank()
        {
            BankDto bankDto =  this._bankView.GetDto() as BankDto;
            BankDto savedDto= bankDto;
            if (this._bankView.GetMode().Equals(ActionMode.New))
            {
                savedDto = this._bankRestClient.Add(bankDto);
            }
            else
            {
                savedDto = this._bankRestClient.Update(bankDto);
            }

            if (this._bankView.ShowMessage().Equals(DialogResult.Yes))
            {
                this._bankView.SetDto(savedDto);
            }
            else
            {
                this._bankView.ClearUI();
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
