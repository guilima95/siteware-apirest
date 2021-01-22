using Siteware.Domain.Entities.Base;
using System;

namespace Siteware.Domain.Entities
{
    public class Promotion : Entity
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public DateTime Validity { get; set; }
    }
}
