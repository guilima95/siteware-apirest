using AutoMapper;
using Siteware.API.ViewModels;
using Siteware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.API.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            #region ViewModelToDomain
            CreateMap<ProductViewModel, Product>();
            #endregion
            #region DomainToViewModel
            CreateMap<Product, ProductViewModel>();
            #endregion


            #region ViewModelToDomain
            CreateMap<PromotionViewModel, Promotion>();
            #endregion
            #region DomainToViewModel
            CreateMap<Promotion, PromotionViewModel>();
            #endregion
        }
    }
}