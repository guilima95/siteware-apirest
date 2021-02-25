using MyFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinance.Application.Models
{
    public class FinanceRequest
    {
        public string Description { get; set; }
        public Domain.Entities.Type Type { get; set; }
        public Frequency Frequency { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Profile { get; set; }
    }
}
