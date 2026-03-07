using Invoice.UI.DTO;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Item
{
    internal class ItemEntityLoader : EntityLoader<ItemMasterDto>
    {
        private readonly ItemRestClient _restClient;

        public ItemEntityLoader(ItemRestClient itemRestClient)
        {
            this._restClient = itemRestClient;
        }

        public List<ItemMasterDto> GetEntities()
        {
            return this._restClient.GetAll(true,false);
        }
    }
}
