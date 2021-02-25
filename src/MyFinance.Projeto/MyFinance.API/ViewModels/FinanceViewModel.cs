using MyFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Type = MyFinance.Domain.Entities.Type;

namespace MyFinance.API.ViewModels
{
    public class FinanceViewModel
    {
        public string Description { get; set; }
        public Type Type { get; set; }
        public Frequency Frequency { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
