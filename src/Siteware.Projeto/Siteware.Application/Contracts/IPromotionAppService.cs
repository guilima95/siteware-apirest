using Siteware.Application.Contracts.Base;
using Siteware.Domain.Entities;
using Siteware.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Application.Contracts
{
    public interface IPromotionAppService : IAppService<Promotion>
    {
        Task NewPromotion(PromotionModel request);
    }
}
