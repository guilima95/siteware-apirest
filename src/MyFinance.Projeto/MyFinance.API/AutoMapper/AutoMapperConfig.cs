using AutoMapper;
using MyFinance.API.ViewModels;
using MyFinance.Domain.Entities;

namespace MyFinance.API.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            #region ViewModelToDomain
            CreateMap<FinanceViewModel, Finance>();
            #endregion
            #region DomainToViewModel
            CreateMap<Finance, FinanceViewModel>();
            #endregion

        }
    }
}