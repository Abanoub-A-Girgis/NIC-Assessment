using System;
using System.Collections.Generic;

namespace NIC_Assessment.Models
{
    public class DateOfBirth : BaseEntity
    {
        public string Type { get; set; }
        public string Note { get; set; }
        public DateTime? DoB { get; set; }
        public int Year { get; set; }
        public int FromYear { get; set; }
        public int ToYear { get; set; }
    }
}
