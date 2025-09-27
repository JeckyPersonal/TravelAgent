using Invoice.UI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Item
{
    public class ItemRestClient
    {
        public static ItemRestClient Instance => new ItemRestClient();

        private ItemRestClient()
        {

        }

        public ItemMasterDto Get(int id)
        {
            return new ItemMasterDto();
        }

        public ItemMasterDto Add(ItemMasterDto payload)
        {
            return new ItemMasterDto();
        }

        public ItemMasterDto Update(ItemMasterDto payload)
        {
            return new ItemMasterDto();
        }

        public List<ItemMasterDto> GetAll()
        {
            return new List<ItemMasterDto>();
        }
    }
}
