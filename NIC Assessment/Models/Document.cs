using System;
using System.Collections.Generic;

namespace NIC_Assessment.Models
{
    public class Document : BaseEntity
    {
        public string Type { get; set; }
        public string DocumentNo { get; set; }
        public string IssuingCountry { get; set; }
        public DateTime? IssuingDate { get; set; }
        public string IssuingCity { get; set; }
        public string Note { get; set; }
    }
}
