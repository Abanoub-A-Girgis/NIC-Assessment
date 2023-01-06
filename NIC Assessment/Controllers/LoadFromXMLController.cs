using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NIC_Assessment.DB;
using NIC_Assessment.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace NIC_Assessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoadFromXMLController : ControllerBase
    {
        public InformationDBContext _context { get; set; }
        public LoadFromXMLController(InformationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public void Get()
        {
            if(_context.Info.Count() == 0)
            {
                string URLXML = "https://scsanctions.un.org/resources/xml/en/consolidated.xml";
                new LoadXML(_context).InsertXMLIntoDB(URLXML);
            }
        }
    }
}
