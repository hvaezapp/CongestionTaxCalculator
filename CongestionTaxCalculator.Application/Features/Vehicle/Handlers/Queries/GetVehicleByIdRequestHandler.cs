using AutoMapper;
using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Application.DTOs.Vehicle;
using CongestionTaxCalculator.Application.Features.City.Requests.Queries;
using CongestionTaxCalculator.Application.Features.Vehicle.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using CongestionTaxCalculator.Domain.Entity;
using CongestionTaxCalculator.Infrastructure.Const;
using CongestionTaxCalculator.Infrastructure.Exceptions;
using MediatR;
using Microsoft.Extensions.Caching.Memory;


namespace CongestionTaxCalculator.Application.Features.Vehicle.Handlers.Queries
{


    public class GetVehicleByIdRequestHandler : IRequestHandler<GetVehicleByIdRequest, BaseCommandResponse>
    {
        
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        private readonly IMemoryCache _cache;

        public GetVehicleByIdRequestHandler(IVehicleRepository vehicleRepository
            , IMapper mapper, IMemoryCache cache)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
            _cache = cache;
        }



        public async Task<BaseCommandResponse> Handle(GetVehicleByIdRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {

                var vehicle = await _vehicleRepository.GetByIdAsync(request.VehicleId, cancellationToken);

                if (vehicle != null)
                {
                    var data = _mapper.Map<VehicleDto>(vehicle);
                    response.Success(data: data);
                }



                    //if (vehicle is not null)
                    //{
                    //    var data = _mapper.Map<VehicleDto>(vehicle);
                    //    response.Success(data: data);
                    //}
                    //else
                    //    response.Failure(message:DefaultConst.NotFound);

                }
            catch (Exception)
            {
                throw;
                //response.Failure(message : ex.Message);
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
