using AutoMapper;
using Invoice.Model;

namespace Invoice.DTO
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Bank
            CreateMap<Bank, BankDto>().ReverseMap();

            //BankDetail
            CreateMap<BankDetail, BankDetailDto>().ReverseMap();

            //Company
            CreateMap<Company, CompanyDto>().ReverseMap();

            //Customer
            CreateMap<Customer, CustomerDto>().ReverseMap();

            //DriverDto
            CreateMap<Driver, DriverDto>().ReverseMap();

            //FinancialYear
            CreateMap<FinancialYear, FinancialYearDto>().ReverseMap();

            //ItemMaster
            CreateMap<ItemMaster, ItemMasterDto>().ReverseMap();

            //Vehicle
            CreateMap<Vehicle, VehicleDto>().ReverseMap();

            //VehicleDetail
            CreateMap<VehicleDetail, VehicleDetailDto>().ReverseMap();

            //Invoice
            CreateMap<Invoice.Model.Invoice, InvoiceDto>().ReverseMap();

            //InvoiceDetail
            CreateMap<InvoiceDetail, InvoiceDetailDto>().ReverseMap();

            CreateMap<VehicleRateConfiguration, VehicleRateDto>()
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.ItemMaster.ItemName))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.ItemMaster.Unit))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.ItemMaster.Quantity))
                .ReverseMap();
        }
    }
}
