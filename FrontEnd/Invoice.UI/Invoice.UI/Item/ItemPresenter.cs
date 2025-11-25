using Invoice.UI.DTO;
using Invoice.UI.Exceptions;
using System;
using System.Collections.Generic;

namespace Invoice.UI.Item
{
    internal class ItemPresenter : BasePresenter
    {
        private readonly ItemRestClient _restClient;
        private IItemView _itemView;

        public ItemPresenter(ItemRestClient restClient)
        {
            _restClient = restClient;
        }

        public override void Close()
        {
            this._itemView.CloseUI();
        }

        public override void SaveAndClose()
        {
            this.saveItem();
            this._itemView.CloseUI();
        }

        private ItemMasterDto saveItem()
        {
            ItemMasterDto itemMaster = this._itemView.GetDto() as ItemMasterDto;
            if (this._itemView.GetMode() == ActionMode.New)
            {
                return this._restClient.Add(itemMaster);
            }
            else
            {
                return this._restClient.Update(itemMaster);
            }
        }

        public override void SaveAndNew()
        {
            try
            {
                this.saveItem();
                this._itemView.ShowMessage();
                this._itemView.ClearUI();
            }
            catch (ValidationException ex) 
            {
                this._itemView.ShowError(ex.Errors);
            }
        }

        protected override object BuidDtoForEdit(int id)
        {
            return this._restClient.Get(id);
        }

        protected override object BuildDto()
        {
            return new ItemMasterDto();
        }

        public void SetView(IItemView itemView)
        {
            this._itemView = itemView;
            base.SetView(itemView);
        }

        internal void LoadIntervals()
        {
            List<ItemIntervalDto> intervals = this._restClient.GetAllIntervals();
            this._itemView.SetIntervalSource(intervals);
        }
    }
}
