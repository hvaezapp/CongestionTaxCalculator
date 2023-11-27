using AutoMapper;
using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.DTOs.CongestionTaxHistory;
using CongestionTaxCalculator.Application.Features.CongestionTaxCal.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using CongestionTaxCalculator.Infrastructure.Const;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Application.Features.CongestionTaxCal.Handlers.Queries
{
    public class GetCongestionTaxHistoryListRequestHandler : IRequestHandler<GetCongestionTaxHistoryListRequest, BaseCommandResponse>
    {
        private const string CongestionListCacheKey = "CongestionList";

        private readonly ICongestionTaxHistoryRepository _congestionTaxHistoryRepository;
        private readonly IMapper _mapper;

        private readonly IMemoryCache _cache;


        public GetCongestionTaxHistoryListRequestHandler(ICongestionTaxHistoryRepository congestionTaxHistoryRepository,
            IMapper mapper , IMemoryCache memoryCache)
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


                var congestionTaxHistories = await _congestionTaxHistoryRepository.GetAllAsyncWithSkip(null ,  skip, take , "City,Vehicle" , cancellationToken);

                var data = _mapper.Map<List<GetCongestionTaxHistoryDto>>(congestionTaxHistories);

                response.Success(data: data, page: request.Page);

            }

            catch (Exception ex)
            {

                response.Failure(ex.Message);
            }

            return response;
        }
    }
}
