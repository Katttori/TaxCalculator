using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.BusinessLogic.DataTransferObjects;
using TaxCalculator.BusinessLogic.Interfaces;
using TaxCalculator.DataAccess.Interfaces;
using TaxCalculator.Entities.Entities;

namespace TaxCalculator.BusinessLogic.Services
{
    internal class TaxBandService : ITaxBandService
    {
        private readonly IRepository<TaxBand> _taxBandRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public TaxBandService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TaxBandService> logger)
        {
            _taxBandRepository = unitOfWork.GetRepository<TaxBand>();
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<TaxBandDto>> GetTaxBandsAsync()
        {
            _logger.LogInformation("Getting tax bands");
            var taxBands = await _taxBandRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<TaxBandDto>>(taxBands);
        }
    }
}
