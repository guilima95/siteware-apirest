using Siteware.Domain.Entities;
using Siteware.Domain.Models;
using Siteware.Domain.Notification;
using Siteware.Domain.Notification.Contracts;
using Siteware.Domain.Repositories;
using Siteware.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Domain.Services
{
    public class PromotionService : NotifierService, IPromotionService
    {
        private readonly IPromotionRepository promotionRepository;
        public PromotionService(INotifier notifier, IPromotionRepository promotionRepository) : base(notifier)
        {
            this.promotionRepository = promotionRepository;
        }

        public async Task<PromotionProductModel> GetPromotion(int type)
        {
            PromotionProductModel response = new PromotionProductModel
            {
                DescriptionPromotion = "",
                PromotionId = 0,
                StatusPromotion = StatusPromotion.Desable,
                TypePromotion = TypePromotion.Undefined
            };

            var data = await promotionRepository.Get(x => (int)x.TypePromotion == type);

            if (data == null)
                Notifier($"Not possible insert product. Promotion {Enum.GetName(typeof(TypePromotion), type)} not found.");
            else
            {
                response.DescriptionPromotion = data.Description;
                response.PromotionId = data.Id;
                response.StatusPromotion = data.StatusPromotion == StatusPromotion.Active ? data.StatusPromotion : StatusPromotion.Desable;
                response.TypePromotion = data.TypePromotion;
            }

            return response;
        }

    }
}
