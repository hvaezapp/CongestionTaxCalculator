using AutoMapper;
using CongestionTaxCalculator.Application.Contracts.Persistence;
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


                var vehicles = await _vehicleRepository.GetAllAsyncWithSkip(skip , take , cancellationToken);

                var data = _mapper.Map<List<VehicleDto>>(vehicles);

                response.Success(data: data , page:request.Page);


            }
            catch (Exception ex)
            {
                response.Failure(message : ex.Message , page: request.Page);
            }


            return response;



            //if (_cache.TryGetValue(categoryListCacheKey, out List<Domain.Entity.Category> categories))
            //{
            //    //categories = cashedCategories.Skip(skip).Take(DefaultConst.TakeCount).ToList();
            //    //categories = cashedCategories;
            //}
            //else
            //{

            //    categories = await _categoryRepository.GetCategories(skip, DefaultConst.TakeCount);


            //    _cache.Set(categoryListCacheKey, categories, TimeSpan.FromSeconds(60));
            //}


            //return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
