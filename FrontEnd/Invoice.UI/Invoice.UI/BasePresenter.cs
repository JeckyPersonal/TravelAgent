using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI
{
    public abstract class BasePresenter
    {
        private IBaseView _view;

        public BasePresenter()
        {
        }

        public void OpenNewUI() 
        {
            this._view.SetDto(this.BuildDto());
            this._view.ShowDialog();
        }

        public void OpenEditUI(int id)
        {
            this._view.SetDto(this.BuidDtoForEdit(id));
            this._view.ShowDialog();
        }

        protected void SetView(IBaseView view)
        {
            this._view = view;
        }

        public abstract void SaveAndClose();

        public abstract void SaveAndNew();

        public abstract void Close();

        protected abstract object BuildDto();

        protected abstract object BuidDtoForEdit(int id);
    }
}
