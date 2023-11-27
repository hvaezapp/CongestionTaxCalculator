using CongestionTaxCalculator.Domain.Entity;

namespace CongestionTaxCalculator.Application.DTOs.Vehicle
{
    public record CreateVehicleDto(string Name, int? ParentId);
}
