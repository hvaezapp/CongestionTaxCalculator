namespace CongestionTaxCalculator.Application.DTOs.CongestionTaxHistory
{
    public record CreateCongestionTaxHistoryDto(int VehicleId, int CityId, List<CrossInfoDto> CrossInfo)
    {
        public CreateCongestionTaxHistoryDto() : this(default, default, new List<CrossInfoDto>())
        {
        }

    }
}
