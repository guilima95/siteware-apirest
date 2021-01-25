using Siteware.Domain.Entities;
using Siteware.Domain.Models;
using Siteware.Domain.Notification.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Domain.Services.Contracts
{
    public interface IPromotionService
    {
        Task<PromotionProductModel> GetPromotion(int typePromotion);

    }
}
