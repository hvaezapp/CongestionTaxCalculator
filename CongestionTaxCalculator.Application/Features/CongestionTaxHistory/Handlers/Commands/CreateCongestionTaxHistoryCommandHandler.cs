using AutoMapper;
using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Application.DTOs.CongestionTaxHistory;
using CongestionTaxCalculator.Application.Features.CongestionTaxHistory.Requests.Commands;
using CongestionTaxCalculator.Application.Responses;
using CongestionTaxCalculator.Infrastructure.Const;
using CongestionTaxCalculator.Infrastructure.Utilities;
using MediatR;

namespace CongestionTaxCalculator.Application.Features.CongestionTaxHistory.Handlers.Commands
{
    public class CreateCongestionTaxHistoryCommandHandler : IRequestHandler<CreateCongestionTaxHistoryCommand, BaseCommandResponse>
    {
        private readonly ICongestionTaxHistoryRepository _congestionTaxHistoryRepository;
        private readonly IHolidayRepository _holidayRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ITaxExemptVehiclesRepository _taxExemptVehiclesRepository;
        private readonly ICongestionTaxRuleRepository _congestionTaxRuleRepository;

        private readonly IMapper _mapper;

        public CreateCongestionTaxHistoryCommandHandler(ICongestionTaxHistoryRepository congestionTaxHistoryRepository,
                                                IMapper mapper, IHolidayRepository holidayRepository, ICongestionTaxRuleRepository congestionTaxRuleRepository,
                                                ICityRepository cityRepository, ITaxExemptVehiclesRepository taxExemptVehiclesRepository)
        {
            _congestionTaxHistoryRepository = congestionTaxHistoryRepository;
            _holidayRepository = holidayRepository;
            _cityRepository = cityRepository;
            _taxExemptVehiclesRepository = taxExemptVehiclesRepository;
            _congestionTaxRuleRepository = congestionTaxRuleRepository;
            _mapper = mapper;
        }


        public async Task<BaseCommandResponse> Handle(CreateCongestionTaxHistoryCommand request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            double taxAmount = 0;
            Domain.Entity.Holiday holiday = null,
            beforeHoliday = null;

            try
            {


                var city = await _cityRepository.GetByIdAsync(request.CreateCongestionTaxHistoryDto.CityId, cancellationToken);

                if (city is not  null)
                {

                    #region Calculate For Tolling St

                    int sumMin = request.CreateCongestionTaxHistoryDto.CrossInfo.Sum(a => a.CrossDateTime.Minute);
                    int crossTollStCount = request.CreateCongestionTaxHistoryDto.CrossInfo.Count(a => a.CrossFromTollingStation);

                    if (sumMin == DefaultConst.OneMin)
                    {
                        if (crossTollStCount >= (request.CreateCongestionTaxHistoryDto.CrossInfo.Count() / 2))
                        {
                            taxAmount = city.MaxTaxAmountPerDay;

                            var newCongestionTaxHistory = new Domain.Entity.CongestionTaxHistory(request.CreateCongestionTaxHistoryDto.VehicleId,
                                                          request.CreateCongestionTaxHistoryDto.CityId,
                                                          taxAmount);


                            var congestionTaxAdded = await _congestionTaxHistoryRepository.Create(newCongestionTaxHistory, cancellationToken);
                            await _congestionTaxHistoryRepository.SaveChanges(cancellationToken);


                            responce.Success(data: _mapper.Map<CongestionTaxHistoryDto>(congestionTaxAdded));

                            return responce;
                        }
                    }

                    #endregion




                    foreach (var item in request.CreateCongestionTaxHistoryDto.CrossInfo)
                    {

                        // check city about congestion tax rules

                        if (city.IsAvailableInHoliday)
                            holiday = await _holidayRepository.GetSingleAsync(a => a.DateCreated.Date == item.CrossDateTime.Date, cancellationToken);


                        var isWeekend = item.CrossDateTime.IsWeekend();
                        var monthName = item.CrossDateTime.ToMonthName();


                        if (city.IsAvailableInBeforeHoliday)
                            beforeHoliday = await _holidayRepository.GetSingleAsync(a => item.CrossDateTime.Date.AddDays(DefaultConst.DayCountToBeforeHoliday) <= a.DateCreated.Date, cancellationToken);




                        var taxExemptVehicles = await _taxExemptVehiclesRepository.GetSingleAsync(a => a.VehicleId == request.CreateCongestionTaxHistoryDto.VehicleId &&
                                                                                                         a.CityId == request.CreateCongestionTaxHistoryDto.CityId,
                                                                                                         cancellationToken);



                        if (CheckIsPossible(holiday, isWeekend,
                                            monthName, beforeHoliday,
                                            taxExemptVehicles, city))
                        {
                            taxAmount = 0;
                            break;
                        }



                        // it's ok get the value from db based city congestion rules

                        var congestionTaxValue = await _congestionTaxRuleRepository.GetSingleAsync(a => ((a.FromTime.Hour >= item.CrossDateTime.Hour &&
                                                                                                   a.FromTime.Minute <= item.CrossDateTime.Minute)) &&
                                                                                                   ((a.ToTime.Hour <= item.CrossDateTime.Hour) &&
                                                                                                   (a.ToTime.Minute >= item.CrossDateTime.Minute)),
                                                                                                   cancellationToken);



                        // get tax from city created values
                        taxAmount = congestionTaxValue.TaxAmount;



                    }



                    var congestionTaxHistory = new Domain.Entity.CongestionTaxHistory(request.CreateCongestionTaxHistoryDto.VehicleId, city.Id, taxAmount);
                    var congestionTax = await _congestionTaxHistoryRepository.Create(congestionTaxHistory, cancellationToken);
                    await _cityRepository.SaveChanges(cancellationToken);


                    responce.Success(data: _mapper.Map<CongestionTaxHistoryDto>(congestionTax));

                    return responce;

                }

            }
            catch (Exception ex)
            {

                throw;
                //responce.Failure(message: ex.Message.ToString());
            }

            return responce;
        }


        private bool CheckIsPossible(Domain.Entity.Holiday holiday, bool isWeekend,
                                    string monthName, Domain.Entity.Holiday beforeHoliday,
                                    Domain.Entity.TaxExemptVehicles taxExempt,
                                    Domain.Entity.City city)
        {
            return ((city.IsAvailableInHoliday && holiday != null) ||
                        (city.IsAvailableInWeekend && isWeekend) ||
                        (city.IsAvailableInDuringJuly && monthName.Contains("July")) ||
                        (city.IsAvailableInBeforeHoliday && beforeHoliday != null) ||
                        (taxExempt != null));
        }
    }
}
