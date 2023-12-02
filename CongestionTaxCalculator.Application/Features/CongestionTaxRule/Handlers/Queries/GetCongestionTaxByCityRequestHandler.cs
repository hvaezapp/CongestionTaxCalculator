using AutoMapper;
using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Application.DTOs.CongestionTaxRule;
using CongestionTaxCalculator.Application.Features.CongestionTaxRule.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using CongestionTaxCalculator.Infrastructure.Const;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace CongestionTaxCalculator.Application.Features.CongestionTaxRule.Handlers.Queries
{
    public class GetCongestionTaxByCityRequestHandler : IRequestHandler<GetCongestionTaxByCityRequest, BaseCommandResponse>
    {
        private const string CongestionTaxByCityCacheKey = "CongestionTaxByCityList";

        private readonly ICongestionTaxRuleRepository _congestionTaxRuleRepository;
        private readonly IMapper _mapper;

        private readonly IMemoryCache _cache;

        public GetCongestionTaxByCityRequestHandler(ICongestionTaxRuleRepository congestionTaxRuleRepository
            , IMapper mapper, IMemoryCache cache)
        {
            _congestionTaxRuleRepository = congestionTaxRuleRepository;
            _mapper = mapper;
            _cache = cache;
        }


        public async Task<BaseCommandResponse> Handle(GetCongestionTaxByCityRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {
                var congestionTaxRules = await _congestionTaxRuleRepository.GetAsync(a=>a.CityId == request.CityId, null, "City", cancellationToken);

                if (congestionTaxRules.Any())
                {
                    var data = _mapper.Map<List<CongestionTaxRuleDto>>(congestionTaxRules);
                    response.Success(data: data);

                }
                else
                    response.Failure(message: DefaultConst.NotFound);



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
