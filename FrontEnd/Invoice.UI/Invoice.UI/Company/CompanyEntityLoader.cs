using Invoice.DTO;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Invoice.UI.Company
{
    internal class CompanyEntityLoader : EntityLoader<CompanyDto>
    {
        private readonly CompanyRestClient _restClient;

        public CompanyEntityLoader(CompanyRestClient restClient)
        {
            this._restClient = restClient;
        }

        public List<CompanyDto> GetEntities()
        {
            return this._restClient.GetAllCompany();
        }
    }
}
