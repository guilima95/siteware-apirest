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

        public async Task<PromotionProductModel> GetPromotion(Entities.TypePromotion type)
        {
            PromotionProductModel response = new PromotionProductModel
            {
                DescriptionPromotion = "",
                PromotionId = 0
            };
            var data = await promotionRepository.Get(x => x.TypePromotion == type).ConfigureAwait(false);

            if (data == null)
                Notifier($"Not possible insert product. Promotion {Enum.GetName(typeof(TypePromotion), type)} not found.");


            if (!HasNotification())
            {
                response.DescriptionPromotion = data.Description;
                response.PromotionId = data.Id;
            }

            return response;
        }

        public async Task<IList<Promotion>> GetPromotions(int id)
        {
            return await promotionRepository.GetList(x => x.Id == id);
        }
    }
}
