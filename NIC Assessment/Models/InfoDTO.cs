using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NIC_Assessment.Models
{
    public class AspNetUsers : BaseEntity
    {
        public string ReferenceNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string FourthName { get; set; }
        public string OriginalScriptName { get; set; }
        public DateTime ListedON { get; set; }
    }

}
