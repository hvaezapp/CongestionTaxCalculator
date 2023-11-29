using AutoMapper;
using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.DTOs.CongestionTaxHistory;
using CongestionTaxCalculator.Application.Features.CongestionTaxHistory.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using CongestionTaxCalculator.Infrastructure.Const;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Application.Features.CongestionTaxHistory.Handlers.Queries
{
    public class GetCongestionTaxHistoryListRequestHandler : IRequestHandler<GetCongestionTaxHistoryListRequest, BaseCommandResponse>
    {
        private const string CongestionTaxHistoryListCacheKey = "CongestionTaxHistoryListCacheKey";

        private readonly ICongestionTaxHistoryRepository _congestionTaxHistoryRepository;
        private readonly IMapper _mapper;

        private readonly IMemoryCache _cache;


        public GetCongestionTaxHistoryListRequestHandler(ICongestionTaxHistoryRepository congestionTaxHistoryRepository,
            IMapper mapper, IMemoryCache memoryCache)
        {
            _congestionTaxHistoryRepository = congestionTaxHistoryRepository;
            _mapper = mapper;
            _cache = memoryCache;
        }

        public async Task<BaseCommandResponse> Handle(GetCongestionTaxHistoryListRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            try
            {
                // paging
                if (request.Page < 1)
                    request.Page = 1;

                int take = DefaultConst.TakeCount;
                int skip = (request.Page - 1) * take;



                if (_cache.TryGetValue(CongestionTaxHistoryListCacheKey, out IEnumerable<Domain.Entity.CongestionTaxHistory> congestionTaxHistories))
                {

                }
                else
                {
                    congestionTaxHistories = await _congestionTaxHistoryRepository.GetAllAsyncWithPaging(null, skip, take, "City,Vehicle", cancellationToken);

                    _cache.Set(CongestionTaxHistoryListCacheKey, congestionTaxHistories, TimeSpan.FromSeconds(60));
                }


                var congestionTaxHistoryDtos = _mapper.Map<List<GetCongestionTaxHistoryDto>>(congestionTaxHistories);

                var data = new GetCongestionTaxHistoryListWithPagingDto
                {

                    congestionTaxHistories = congestionTaxHistoryDtos,
                    page = request.Page,
                };

                response.Success(data: data);

            }

            catch (Exception ex)
            {

                response.Failure(ex.Message);
            }

            return response;
        }
    }
}
