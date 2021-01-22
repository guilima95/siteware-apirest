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

        public async Task<ResponsePromotionProduct> GetPromotion(Entities.TypePromotion type)
        {
            ResponsePromotionProduct response = null;
            var data = await promotionRepository.Get(x => x.TypePromotion == type).ConfigureAwait(false);

            if (data == null)
                Notifier($"Promotion not found.");


            if (!HasNotification())
            {
                response = new ResponsePromotionProduct
                {
                    DescriptionPromotion = data.Description,
                    PromotionId = data.Id
                };
            }


            return response;
        }
    }
}
