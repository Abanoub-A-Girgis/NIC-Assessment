using System;
using System.Collections.Generic;

namespace NIC_Assessment.Models
{
    public class Quality : BaseEntity
    {
        public string QName { get; set; }
        public int? GoodQualityId { get; set; }
        public Info GoodQuality { get; set; }
        public int? LowQualityId { get; set; }
        public Info LowQuality { get; set; }

    }
}
