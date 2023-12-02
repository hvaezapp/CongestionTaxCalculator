using AutoMapper;
using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Application.DTOs.TaxExemptVehicles;
using CongestionTaxCalculator.Application.Features.TaxExemptVehicles.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using CongestionTaxCalculator.Infrastructure.Const;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace CongestionTaxCalculator.Application.Features.TaxExemptVehicles.Handlers.Queries
{
    public class GetTaxExemptVehiclesListRequestHandler : IRequestHandler<GetTaxExemptVehiclesListRequest, BaseCommandResponse>
    {

        private const string TaxExemptVehiclesListCacheKey = "TaxExemptVehiclesList";

        private readonly ITaxExemptVehiclesRepository _taxExemptVehiclesRepository;
        private readonly IMapper _mapper;

        private readonly IMemoryCache _cache;

        public GetTaxExemptVehiclesListRequestHandler(ITaxExemptVehiclesRepository taxExemptVehiclesRepository
            , IMapper mapper, IMemoryCache cache)
        {
            _taxExemptVehiclesRepository = taxExemptVehiclesRepository;
            _mapper = mapper;
            _cache = cache;
        }



        public async Task<BaseCommandResponse> Handle(GetTaxExemptVehiclesListRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {
                // paging
                if (request.Page < 1)
                    request.Page = 1;


                int take = DefaultConst.TakeCount;
                int skip = (request.Page - 1) * take;



                if (_cache.TryGetValue(TaxExemptVehiclesListCacheKey, out IEnumerable<Domain.Entity.TaxExemptVehicles> taxExemptVehicles))
                {

                }
                else
                {
                    taxExemptVehicles = await _taxExemptVehiclesRepository.GetAllAsyncWithPaging(null, skip, take, "City,Vehicle", cancellationToken);

                    _cache.Set(TaxExemptVehiclesListCacheKey, taxExemptVehicles, TimeSpan.FromSeconds(60));
                }


                var taxExemptVehiclesDtos = _mapper.Map<List<TaxExemptVehiclesDto>>(taxExemptVehicles);


                var data = new GetTaxExemptVehicleListWithPagingDto
                {
                    taxExemptVehicles = taxExemptVehiclesDtos,
                    page = request.Page,
                };

                response.Success(data: data);


            }
            catch (Exception ex)
            {
                throw;
                //response.Failure(message: ex.Message);
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
