using AutoMapper;
using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Application.DTOs.CongestionTaxRule;
using CongestionTaxCalculator.Application.DTOs.CongestionTaxRule.Validators;
using CongestionTaxCalculator.Application.Features.CongestionTaxRule.Requests.Commands;
using CongestionTaxCalculator.Application.Responses;
using MediatR;

namespace CongestionTaxCalculator.Application.Features.CongestionTaxRule.Handlers.Commands
{
    public class CreateCongestionTaxRuleCommandHandler : IRequestHandler<CreateCongestionTaxRuleCommand, BaseCommandResponse>
    {

        private readonly ICongestionTaxRuleRepository _congestionTaxHourAndAmountRepository;
        private readonly IMapper _mapper;

        public CreateCongestionTaxRuleCommandHandler(ICongestionTaxRuleRepository congestionTaxHourAndAmountRepository,
            IMapper mapper)
        {
            _congestionTaxHourAndAmountRepository = congestionTaxHourAndAmountRepository;
            _mapper = mapper;
        }


        public async Task<BaseCommandResponse> Handle(CreateCongestionTaxRuleCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {
                var validator = new CreateCongestionTaxRuleValidator();

                var validationResult = await validator.ValidateAsync(request.createCongestionTaxRuleDto);

                if (validationResult.IsValid == false)
                {
                    var Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    response.Failure(errors: Errors);
                }
                else
                {


                    // var congestionTaxRule = _mapper.Map<Domain.Entity.CongestionTaxRule>(request.createCongestionTaxRuleDto);


                    var fromTime = DateTime.Parse(request.createCongestionTaxRuleDto.FromTime);
                    var toTime = DateTime.Parse(request.createCongestionTaxRuleDto.ToTime);

                    var congestionTaxRule = new Domain.Entity.CongestionTaxRule
                    {
                        CityId = request.createCongestionTaxRuleDto.CityId,
                        TaxAmount = request.createCongestionTaxRuleDto.TaxAmount
                    };

                 
                    congestionTaxRule.FromTime = fromTime;
                    congestionTaxRule.ToTime = toTime;


                    congestionTaxRule = await _congestionTaxHourAndAmountRepository.Create(congestionTaxRule, cancellationToken);
                    await _congestionTaxHourAndAmountRepository.SaveChanges(cancellationToken);


                    response.Success(data: _mapper.Map<CongestionTaxRuleDto>(congestionTaxRule));

                }
            }
            catch (Exception ex)
            {
                throw;
                //response.Failure(message: ex.Message.ToString());
            }

            return response;
        }
    }
}
