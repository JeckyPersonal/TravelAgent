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
            CreateMap<ItemMaster, ItemMasterDto>()
                .ForMember(dest => dest.IntervalId, opt => opt.MapFrom(x => x.IntervalId))
                .ForMember(dest => dest.IntervalName, opt => opt.MapFrom(x => x.Interval.IntervalName))
                .ReverseMap()
                .ForMember(dest=>dest.Interval, opt=> opt.Ignore());

            //Vehicle
            CreateMap<Vehicle, VehicleDto>().ReverseMap();

            //VehicleDetail
            CreateMap<VehicleDetail, VehicleDetailDto>().ReverseMap();

            ////Invoice
            //CreateMap<Invoice.Model.Invoice, InvoiceDto>().ReverseMap();

            //InvoiceDetail
            CreateMap<InvoiceDetail, InvoiceDetailDto>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.Item.Id))
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.Item.ItemName))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Item.Unit))
                .ForMember(dest => dest.VoucherNo, opt => opt.MapFrom(src => src.VoucherDetail.Voucher.VoucherNo))
                .ForMember(dest => dest.AmountBeforeGST, opt => opt.MapFrom(src => src.AmountBeforeTax))
                .ReverseMap()
                .ForMember(dest => dest.VoucherDetail, opt => opt.Ignore())
                .ForMember(dest => dest.Item, opt => opt.Ignore());

            CreateMap<VehicleRateConfiguration, VehicleRateDto>()
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.ItemMaster.ItemName))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.ItemMaster.Unit))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.ItemMaster.Quantity))   
                .ForMember(dest => dest.Interval, opt => opt.MapFrom(src => src.ItemMaster.Interval.Interval))
                .ForMember(dest => dest.IntervalName, opt => opt.MapFrom(src => src.ItemMaster.Interval.IntervalName))
                .ReverseMap()
                .ForMember(dest => dest.ItemMaster, opt => opt.Ignore());

            CreateMap<VehicleRateConfiguration, CustomerRateDto>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemMaster.Id))
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.ItemMaster.ItemName))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.ItemMaster.Unit))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.ItemMaster.Quantity))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer.Id))
                .ForMember(dest => dest.Interval, opt => opt.MapFrom(src => src.ItemMaster.Interval.Interval))
                .ForMember(dest => dest.IntervalName, opt => opt.MapFrom(src => src.ItemMaster.Interval.IntervalName))
                .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.Vehicle.Id))
                .ForMember(dest => dest.VehicleName, opt => opt.MapFrom(src => src.Vehicle.VehicleType))
                .ReverseMap()
                .ForMember(dest => dest.ItemMaster, opt => opt.Ignore())
				.ForMember(dest => dest.Vehicle, opt=> opt.Ignore());

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

            CreateMap<Model.Invoice, DTO.InvoiceDto>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer.Id))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.AccountNumberId, opt => opt.MapFrom(src => src.BankDetailId))
                .ForMember(dest => dest.AccountNumberId, opt => opt.MapFrom(src => src.BankDetail.Id))
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.BankDetail.AccountNumber))
                .ForMember(dest => dest.Vouchers, opt => opt.Ignore())
                .ForMember(dest => dest.BankId, opt => opt.MapFrom(src => src.BankDetail.Bank.Id))
                .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.BankDetail.Bank.BankName))
                .ReverseMap()
                .ForMember(dest => dest.Vouchers, opt => opt.Ignore());
            //.ForMember(dest => dest.BankDetail, opt => opt.Ignore())
            //.ForMember(dest => dest.BankDetail.Bank, opt => opt.Ignore());

            CreateMap<Model.ItemInterval, ItemIntervalDto>().ReverseMap();

            CreateMap<Model.PaymentReceived, PaymentDto>().ReverseMap();

            CreateMap<Model.TenderMaster, TenderMasterDto>()
                .ForMember(dest=> dest.FuelRates, opt=>opt.MapFrom(src=>src.FuelRate))
                .ReverseMap();
            CreateMap<Model.FuelRate, FuelRateDto>().ReverseMap();
        }
    }
}
