using AutoMapper;
using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.DTOs.Vehicle;
using CongestionTaxCalculator.Application.Features.City.Requests.Queries;
using CongestionTaxCalculator.Application.Features.Vehicle.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using CongestionTaxCalculator.Infrastructure.Const;
using MediatR;
using Microsoft.Extensions.Caching.Memory;


namespace CongestionTaxCalculator.Application.Features.Vehicle.Handlers.Queries
{


    public class GetVehicleListRequestHandler : IRequestHandler<GetVehicleListRequest, BaseCommandResponse>
    {
        private const string VehicleListCacheKey = "VehicleList";

        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        private readonly IMemoryCache _cache;

        public GetVehicleListRequestHandler(IVehicleRepository vehicleRepository
            , IMapper mapper, IMemoryCache cache)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
            _cache = cache;
        }



        public async Task<BaseCommandResponse> Handle(GetVehicleListRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {
                // paging
                if (request.Page < 1)
                    request.Page = 1;


                int take = DefaultConst.TakeCount;
                int skip = (request.Page - 1) * take;




                if (_cache.TryGetValue(VehicleListCacheKey, out IEnumerable<Domain.Entity.Vehicle> vehicles))
                {

                }
                else
                {
                    // Read From Dapper

                    vehicles = await _vehicleRepository.GetAllWithPagingWithDapper(skip, take, cancellationToken);


                    // Read From EF
                    //vehicles = await _vehicleRepository.GetAllAsyncWithSkip(skip, take, cancellationToken);

                    _cache.Set(VehicleListCacheKey, vehicles, TimeSpan.FromSeconds(60));
                }


                var data = _mapper.Map<List<VehicleDto>>(vehicles);

                response.Success(data: data, page: request.Page);


            }
            catch (Exception ex)
            {
                response.Failure(message : ex.Message , page: request.Page);
            }


            return response;


        }
    }
}
