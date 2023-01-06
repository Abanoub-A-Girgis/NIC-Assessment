using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NIC_Assessment.Models
{
    public class Info : BaseEntity
    {
        public string ReferenceNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string FourthName { get; set; }
        public string OriginalScriptName { get; set; }
        public DateTime ListedON { get; set; }
        public string Comments1 { get; set; }
        public List<Title> Titles { get; set; }
        public List<Designation> Designations { get; set; }
        public List<Address> Addresses { get; set; }
        public List<DateOfBirth> DoB { get; set; }
        public List<PlaceOfBirth> PoB { get; set; }
        public List<Document> Documents { get; set; }
        [InverseProperty("GoodQuality")]
        public List<Quality> GQualities { get; set; }
        [InverseProperty("LowQuality")]
        public List<Quality> LQualities { get; set; }
        public List<Nationality> Nationalities { get; set; }
    }

}
