using AutoMapper;
using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.Features.City.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using CongestionTaxCalculator.Infrastructure.Const;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace CongestionTaxCalculator.Application.Features.City.Handlers.Queries
{


    public class GetCityListRequestHandler : IRequestHandler<GetCityListRequest, BaseCommandResponse>
    {
        private const string CityListCacheKey = "CityList";

        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        private readonly IMemoryCache _cache;

        public GetCityListRequestHandler(ICityRepository cityRepository
            , IMapper mapper, IMemoryCache cache)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
            _cache = cache;
        }



        public async Task<BaseCommandResponse> Handle(GetCityListRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {
                

                // paging
                if (request.Page < 1)
                    request.Page = 1;


                int take = DefaultConst.TakeCount;
                int skip = (request.Page - 1) * take;


                

                if (_cache.TryGetValue(CityListCacheKey, out IEnumerable<Domain.Entity.City> cities))
                {
                  
                }
                else
                {

                    // Read From Dapper
                    cities = await _cityRepository.GetAllWithPagingWithDapper(skip, take, cancellationToken);


                    // Read From EF
                    //cities = await _cityRepository.GetAllAsyncWithSkip(skip, take, cancellationToken);
                    _cache.Set(CityListCacheKey, cities, TimeSpan.FromSeconds(60));
                }

                var cityDtos = _mapper.Map<List<CityDto>>(cities);


                var data = new GetCityListWithPagingDto
                {
                    cities = cityDtos,
                    page = request.Page,
                };


                response.Success(data: data);


            }
            catch (Exception ex)
            {
                response.Failure(message: ex.Message);
            }


            return response;



        
        }
    }
}
