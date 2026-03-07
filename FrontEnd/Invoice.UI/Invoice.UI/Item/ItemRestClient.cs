using Invoice.DTO;
using Invoice.UI.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Item
{
    public class ItemRestClient : BaseRestClient
    {
        public static ItemRestClient Instance => new ItemRestClient();

        private ItemRestClient() : base("api/item")
        {

        }

        public ItemMasterDto Get(int id)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get/{id}", Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<ItemMasterDto>(response);
        }

        public ItemMasterDto Add(ItemMasterDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"add", Method.Post);
            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<ItemMasterDto>(response);
        }

        public ItemMasterDto Update(ItemMasterDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"update/{payload.Id}", Method.Put);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<ItemMasterDto>(response);
        }

        public List<ItemMasterDto> GetAll()
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get-all", Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<List<ItemMasterDto>>(response);
        }

        public List<ItemMasterDto> GetAll(bool userDefined,bool systemDefined)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get-all", Method.Get);
            if (userDefined) 
            {
                request.AddQueryParameter("userdefine", userDefined.ToString());
            }

            if (systemDefined) 
            {
                request.AddQueryParameter("systemdefine", systemDefined.ToString());
            }

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<List<ItemMasterDto>>(response);
        }

        internal List<ItemIntervalDto> GetAllIntervals()
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get-all-interval", Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<List<ItemIntervalDto>>(response);
        }

        internal ItemMasterDto Delete(ItemMasterDto itemDto)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"delete/{itemDto.Id}", Method.Delete);

            RestResponse response = client.ExecuteDelete(request);

            return this.ProcessResponse<ItemMasterDto>(response);
        }
    }
}
