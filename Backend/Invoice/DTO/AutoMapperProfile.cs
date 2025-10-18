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

            CreateMap<VehicleRateConfiguration, CustomerRateDto>()
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.ItemMaster.ItemName))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.ItemMaster.Unit))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.ItemMaster.Quantity))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer.Id))
                .ReverseMap();

            CreateMap<VoucherMaster, VoucherMasterDto>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer.Id))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => src.Driver.DriverName))
                .ForMember(dest => dest.DriverId, opt => opt.MapFrom(src => src.Driver.Id))
                .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.Vehicle.Id))
                .ForMember(dest => dest.VehicleType, opt => opt.MapFrom(src => src.Vehicle.VehicleType))
                .ForMember(dest => dest.RegistrationId, opt => opt.MapFrom(src => src.VehicleDetail.Id))
                .ForMember(dest => dest.RegistrationNo, opt => opt.MapFrom(src => src.VehicleDetail.RegistrationNumber))
                .ReverseMap();

            CreateMap<VoucherDetail, VoucherDetailDto>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.Item.Id))
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.Item.ItemName))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Item.Unit))
                .ReverseMap();
        }
    }
}
