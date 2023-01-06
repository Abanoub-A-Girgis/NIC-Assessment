using Microsoft.AspNetCore.Mvc;
using NIC_Assessment.DB;
using NIC_Assessment.Models;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace NIC_Assessment.API
{
    public class LoadXML
    {
        public InformationDBContext _context { get; set; }
        public LoadXML(InformationDBContext context)
        {
            _context = context;
        }
        public void InsertXMLIntoDB(string URL)
        {
            XDocument xdoc = XDocument.Load(URL);
            foreach (XElement element in xdoc.Descendants("INDIVIDUAL"))
            {
                Info CurrentInfo = new Info();
                List<Address> addresses = new List<Address>();
                List<DateOfBirth> DoBs = new List<DateOfBirth>();
                List<PlaceOfBirth> PoBs = new List<PlaceOfBirth>();
                List<Document> documents = new List<Document>();
                List<Quality> goodQualities = new List<Quality>();
                List<Quality> lowQualities = new List<Quality>();
                foreach (XElement innerElement in element.Descendants())
                {
                    switch (innerElement.Name.ToString())
                    {
                        case "REFERENCE_NUMBER":
                            if (innerElement.FirstNode != null)
                                CurrentInfo.ReferenceNo = innerElement.FirstNode.ToString();
                            break;

                        case "FIRST_NAME":
                            if (innerElement.FirstNode != null)
                                CurrentInfo.FirstName = innerElement.FirstNode.ToString();
                            break;

                        case "SECOND_NAME":
                            if (innerElement.FirstNode != null)
                                CurrentInfo.SecondName = innerElement.FirstNode.ToString();
                            break;

                        case "THIRD_NAME":
                            if (innerElement.FirstNode != null)
                                CurrentInfo.ThirdName = innerElement.FirstNode.ToString();
                            break;

                        case "FOURTH_NAME":
                            if (innerElement.FirstNode != null)
                                CurrentInfo.FourthName = innerElement.FirstNode.ToString();
                            break;

                        case "NAME_ORIGINAL_SCRIPT":
                            if (innerElement.FirstNode != null)
                                CurrentInfo.OriginalScriptName = innerElement.FirstNode.ToString();
                            break;

                        case "LISTED_ON":
                            if (innerElement.FirstNode != null)
                                CurrentInfo.ListedON = DateTime.Parse(innerElement.FirstNode.ToString());
                            break;

                        case "COMMENTS1":
                            if (innerElement.FirstNode != null)
                                CurrentInfo.Comments1 = innerElement.FirstNode.ToString();
                            break;

                        case "TITLE":
                            List<Title> titles = new List<Title>();
                            foreach (XElement innerTitle in innerElement.Descendants())
                            {
                                if (innerTitle.FirstNode != null)
                                {
                                    Title title = new Title();
                                    title.TName = innerTitle.FirstNode.ToString();
                                    titles.Add(title);
                                }
                            }
                            _context.Title.AddRange(titles);
                            _context.SaveChanges();
                            CurrentInfo.Titles = titles;
                            break;

                        case "DESIGNATION":
                            List<Designation> designations = new List<Designation>();
                            foreach (XElement innerDesignation in innerElement.Descendants())
                            {
                                if (innerDesignation.FirstNode != null)
                                {
                                    Designation designation = new Designation();
                                    designation.Note = innerDesignation.FirstNode.ToString();
                                    designations.Add(designation);
                                }
                            }
                            _context.Designation.AddRange(designations);
                            _context.SaveChanges();
                            CurrentInfo.Designations = designations;
                            break;

                        case "INDIVIDUAL_ADDRESS":
                            Address address = new Address();
                            foreach (XElement innerAddress in innerElement.Descendants())
                            {
                                if (innerAddress.FirstNode != null)
                                {
                                    switch (innerAddress.Name.ToString())
                                    {
                                        case "STATE_PROVINCE":
                                            address.State = innerAddress.FirstNode.ToString();
                                            break;
                                        case "COUNTRY":
                                            address.Country = innerAddress.FirstNode.ToString();
                                            break;
                                        case "NOTE":
                                            address.Note = innerAddress.FirstNode.ToString();
                                            break;
                                        case null:
                                            break;
                                    }
                                }
                            }
                            addresses.Add(address);
                            break;

                        case "INDIVIDUAL_DATE_OF_BIRTH":
                            DateOfBirth DoB = new DateOfBirth();
                            foreach (XElement innerDoB in innerElement.Descendants())
                            {
                                if (innerDoB.FirstNode != null)
                                {
                                    switch (innerDoB.Name.ToString())
                                    {
                                        case "TYPE_OF_DATE":
                                            DoB.Type = innerDoB.FirstNode.ToString();
                                            break;
                                        case "NOTE":
                                            DoB.Note = innerDoB.FirstNode.ToString();
                                            break;
                                        case "DATE":
                                            DoB.DoB = DateTime.Parse(innerDoB.FirstNode.ToString());
                                            break;
                                        case "YEAR":
                                            DoB.Year = int.Parse(innerDoB.FirstNode.ToString());
                                            break;
                                        case "FROM_YEAR":
                                            DoB.FromYear = int.Parse(innerDoB.FirstNode.ToString());
                                            break;
                                        case "TO_YEAR":
                                            DoB.ToYear = int.Parse(innerDoB.FirstNode.ToString());
                                            break;
                                        case null:
                                            break;
                                    }
                                }
                            }
                            DoBs.Add(DoB);
                            break;

                        case "INDIVIDUAL_PLACE_OF_BIRTH":
                            PlaceOfBirth PoB = new PlaceOfBirth();
                            foreach (XElement innerPoB in innerElement.Descendants())
                            {
                                if (innerPoB.FirstNode != null)
                                {
                                    switch (innerPoB.Name.ToString())
                                    {
                                        case "CITY":
                                            PoB.City = innerPoB.FirstNode.ToString();
                                            break;
                                        case "STATE_PROVINCE":
                                            PoB.State = innerPoB.FirstNode.ToString();
                                            break;
                                        case "COUNTRY":
                                            PoB.Country = innerPoB.FirstNode.ToString();
                                            break;
                                        case null:
                                            break;
                                    }
                                }
                            }
                            PoBs.Add(PoB);
                            break;

                        case "INDIVIDUAL_DOCUMENT":
                            Document document = new Document();
                            foreach (XElement innerDocument in innerElement.Descendants())
                            {
                                if (innerDocument.FirstNode != null)
                                {
                                    switch (innerDocument.Name.ToString())
                                    {
                                        case "TYPE_OF_DOCUMENT":
                                            document.Type = innerDocument.FirstNode.ToString();
                                            break;
                                        case "NUMBER":
                                            document.DocumentNo = innerDocument.FirstNode.ToString();
                                            break;
                                        case "ISSUING_COUNTRY":
                                            document.IssuingCountry = innerDocument.FirstNode.ToString();
                                            break;
                                        case "DATE_OF_ISSUE":
                                            document.IssuingDate = DateTime.Parse(innerDocument.FirstNode.ToString());
                                            break;
                                        case "CITY_OF_ISSUE":
                                            document.IssuingCity = innerDocument.FirstNode.ToString();
                                            break;
                                        case null:
                                            break;
                                    }
                                }
                            }
                            documents.Add(document);
                            break;

                        case "INDIVIDUAL_ALIAS":
                            Quality quality = new Quality();
                            bool Good = false;
                            bool Low = false;
                            foreach (XElement innerQuality in innerElement.Descendants())
                            {
                                if (innerQuality.FirstNode != null)
                                {
                                    switch (innerQuality.Name.ToString())
                                    {
                                        case "QUALITY":
                                            if (innerQuality.FirstNode.ToString() == "Good")
                                                Good = true;
                                            else if (innerQuality.FirstNode.ToString() == "Low")
                                                Low = true;
                                            break;
                                        case "ALIAS_NAME":
                                            quality.QName = innerQuality.FirstNode.ToString();
                                            break;
                                        case null:
                                            break;
                                    }
                                }
                            }
                            if (Good)
                                goodQualities.Add(quality);
                            else if (Low)
                                lowQualities.Add(quality);
                            break;

                        case "NATIONALITY":
                            List<Nationality> nationalities = new List<Nationality>();
                            foreach (XElement innerNationality in innerElement.Descendants())
                            {
                                if (innerNationality.FirstNode != null)
                                {
                                    Nationality nationality = new Nationality();
                                    nationality.CountryName = innerNationality.FirstNode.ToString();
                                    nationalities.Add(nationality);
                                }
                            }
                            _context.Nationality.AddRange(nationalities);
                            _context.SaveChanges();
                            CurrentInfo.Nationalities = nationalities;
                            break;
                        case null:
                            break;

                    }
                }
                _context.Address.AddRange(addresses);
                _context.SaveChanges();
                CurrentInfo.Addresses = addresses;

                _context.DateOfBirth.AddRange(DoBs);
                _context.SaveChanges();
                CurrentInfo.DoB = DoBs;

                _context.PlaceOfBirth.AddRange(PoBs);
                _context.SaveChanges();
                CurrentInfo.PoB = PoBs;

                _context.Document.AddRange(documents);
                _context.SaveChanges();
                CurrentInfo.Documents = documents;

                _context.Quality.AddRange(goodQualities);
                _context.SaveChanges();
                CurrentInfo.GQualities = goodQualities;

                _context.Quality.AddRange(lowQualities);
                _context.SaveChanges();
                CurrentInfo.LQualities = lowQualities;

                _context.Info.Add(CurrentInfo);
                _context.SaveChanges();
            }            
        }
    }

}
