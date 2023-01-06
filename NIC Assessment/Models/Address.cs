using System;
using System.Collections.Generic;

namespace NIC_Assessment.Models
{
    public class Address : BaseEntity
    {
        public string State { get; set; }
        public string Country { get; set; }
        public string Note { get; set; }
    }
}
