using Siteware.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Application.Contracts.Base
{
    public interface ICalculatePriceTotalBase
    {
        Task<decimal> CalculatePriceTotal(ProductCartModel productCart);
    }
}
