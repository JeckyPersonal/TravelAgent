using AutoMapper;
using Invoice.DTO;
using Invoice.Model;
using Invoice.Service;
using System.ComponentModel.Design;

namespace Invoice.Handler
{
    public class CompanyCreator
    {
        private readonly ICompanyService _companyService;
        private readonly IItemMasterService _itemMasterService;
        private readonly IMapper _mapper;
        private readonly InvoiceDBContext _dbContext;

        public CompanyCreator(ICompanyService companyService, IItemMasterService itemMasterService, InvoiceDBContext dbContext, IMapper mapper)
        {
            _companyService = companyService;
            _itemMasterService = itemMasterService;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<Model.Company> CreateNew(CompanyDto company)
        {
            Model.Company newCompany= this._mapper.Map<Model.Company>(company);
            using (var transaction = await this._dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    newCompany.Items = new List<ItemMaster>
                    {
                        new Model.ItemMaster
                        {
                            SourceSystem=true,
                            SourceInvoice=false,
                            SourceVoucher=false,
                            IntervalId = 6,
                            AppliedGST = true,
                            ItemName = Constants.SYS_ITEM_TENDER_ADJESTMENT,
                            ItemDescription= "This is a default system item.",
                        },
                         new Model.ItemMaster
                        {
                            SourceSystem = true,
                            SourceInvoice = false,
                            SourceVoucher = false,
                            IntervalId = 6,
                            AppliedGST = true,
                            ItemName = Constants.SYS_ITEM_FUEL_ADJESTMENT,
                            ItemDescription = "This is a default system item.",
                        }
                    };

                    Model.Company response = await this._companyService.Add(newCompany);

                    await transaction.CommitAsync();
                    
                    return response;
                }
                catch (Exception ex) 
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }
        }
    }
}
