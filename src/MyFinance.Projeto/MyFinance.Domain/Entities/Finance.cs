using MyFinance.Domain.Entities.Base;
using System;

namespace MyFinance.Domain.Entities
{
    public class Finance : Entity
    {
        public string Description { get; set; }
        public Type Type { get; set; }
        public Frequency Frequency { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
    }

    public enum Frequency
    {
        Eventual = 1,
        Recorrente = 2
    }

    public enum Type
    {
        Saida = 1,
        Entrada = 2
    }
}
