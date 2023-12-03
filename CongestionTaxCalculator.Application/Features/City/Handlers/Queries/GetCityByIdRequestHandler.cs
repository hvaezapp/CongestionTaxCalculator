using AutoMapper;
using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.Features.City.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using CongestionTaxCalculator.Infrastructure.Const;
using CongestionTaxCalculator.Infrastructure.Exceptions;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CongestionTaxCalculator.Application.Features.City.Handlers.Queries
{


    public class GetCityByIdRequestHandler : IRequestHandler<GetCityByIdRequest, BaseCommandResponse>
    {
       

        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

      

        public GetCityByIdRequestHandler(ICityRepository cityRepository
            , IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
            
        }



        public async Task<BaseCommandResponse> Handle(GetCityByIdRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {
                
                var city = await _cityRepository.GetByIdAsync(request.CityId, cancellationToken);

                if (city != null)
                {
                    var data = _mapper.Map<CityDto>(city);
                    response.Success(data: data);
                }





            }
            catch (Exception)
            {
                throw;
                // response.Failure(message: ex.Message);
            }


            return response;

        }
    }
}
