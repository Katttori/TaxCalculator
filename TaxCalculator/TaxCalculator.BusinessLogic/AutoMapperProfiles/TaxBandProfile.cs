using AutoMapper;
using TaxCalculator.BusinessLogic.DataTransferObjects;
using TaxCalculator.Entities.Entities;

namespace TaxCalculator.BusinessLogic.AutoMapperProfiles
{
    public class TaxBandProfile : Profile
    {
        public TaxBandProfile()
        {
            CreateMap<TaxBand, TaxBandDto>().ReverseMap();
        }
    }
}
