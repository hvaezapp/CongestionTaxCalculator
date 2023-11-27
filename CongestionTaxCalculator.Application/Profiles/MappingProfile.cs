using AutoMapper;
using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.DTOs.CongestionTaxHistory;
using CongestionTaxCalculator.Application.DTOs.CongestionTaxRule;
using CongestionTaxCalculator.Application.DTOs.Holiday;
using CongestionTaxCalculator.Application.DTOs.TaxExemptVehicles;
using CongestionTaxCalculator.Application.DTOs.Vehicle;
using CongestionTaxCalculator.Domain.Entity;

namespace CongestionTaxCalculator.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region City Mapping

            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<City, CreateCityDto>().ReverseMap();

            #endregion


            #region Vehicle Mapping

            CreateMap<Vehicle, VehicleDto>().ReverseMap();
            CreateMap<Vehicle, CreateVehicleDto>().ReverseMap();

            #endregion



            #region Holiday Mapping

            CreateMap<Holiday, HolidayDto>().ReverseMap();
            CreateMap<Holiday, CreateHolidayDto>().ReverseMap();

            #endregion



            #region CongestionTaxRule Mapping

            CreateMap<CongestionTaxRule, CongestionTaxRuleDto>().ReverseMap();
            CreateMap<CongestionTaxRule, CreateCongestionTaxRuleDto>().ReverseMap();

            #endregion





            #region TaxExemptVehicles Mapping

            CreateMap<TaxExemptVehicles, TaxExemptVehiclesDto>().ReverseMap();
            CreateMap<TaxExemptVehicles, CreateTaxExemptVehiclesDto>().ReverseMap();

            #endregion



            #region CongestionTaxHistory Mapping

            CreateMap<CongestionTaxHistory, GetCongestionTaxHistoryDto>().ReverseMap();
            CreateMap<CongestionTaxHistory, CongestionTaxHistoryDto>().ReverseMap();
            CreateMap<CongestionTaxHistory, CreateCongestionTaxHistoryDto>().ReverseMap();

            #endregion



        }
    }
}
