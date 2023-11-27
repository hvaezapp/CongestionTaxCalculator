using AutoMapper;
using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Application.DTOs.CongestionTaxHistory;
using CongestionTaxCalculator.Application.DTOs.Holiday;
using CongestionTaxCalculator.Application.Features.Holiday.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using CongestionTaxCalculator.Infrastructure.Const;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace CongestionTaxCalculator.Application.Features.Holiday.Handlers.Queries
{
    public class GetHolidayListRequestHandler : IRequestHandler<GetHolidayListRequest, BaseCommandResponse>
    {

        private const string HolidayListCacheKey = "HolidayList";

        private readonly IHolidayRepository _holidayRepository;
        private readonly IMapper _mapper;

        private readonly IMemoryCache _cache;


        public GetHolidayListRequestHandler(IHolidayRepository holidayRepository
           , IMapper mapper, IMemoryCache cache)
        {
            _holidayRepository = holidayRepository;
            _mapper = mapper;
            _cache = cache;
        }


        public async Task<BaseCommandResponse> Handle(GetHolidayListRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {
                // paging
                if (request.Page < 1)
                    request.Page = 1;


                int take = DefaultConst.TakeCount;
                int skip = (request.Page - 1) * take;


                if (_cache.TryGetValue(HolidayListCacheKey, out IEnumerable<Domain.Entity.Holiday> holidays))
                {

                }
                else
                {
                    holidays = await _holidayRepository.GetAllAsyncWithSkip(null, skip, take, cancellationToken);

                    _cache.Set(HolidayListCacheKey, holidays, TimeSpan.FromSeconds(60));
                }


                var data = _mapper.Map<List<HolidayDto>>(holidays);

                response.Success(data: data, page: request.Page);



            }
            catch (Exception ex)
            {
                response.Failure(message: ex.Message, page: request.Page);
            }


            return response;
        }
    }
}
