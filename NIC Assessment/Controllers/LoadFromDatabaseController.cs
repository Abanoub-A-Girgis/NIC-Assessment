using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NIC_Assessment.DB;
using NIC_Assessment.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using NIC_Assessment.Models;
using Microsoft.EntityFrameworkCore;

namespace NIC_Assessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoadFromDatabaseController : ControllerBase
    {
        public InformationDBContext _context { get; set; }
        public LoadFromDatabaseController(InformationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<AspNetUsers> LoadFromDatabase()
        {
            var allInfo = _context.Info.Select(i => new AspNetUsers {Id = i.Id ,ReferenceNo = i.ReferenceNo, FirstName = i.FirstName, SecondName = i.SecondName, ThirdName = i.ThirdName,
                                                                FourthName = i.FourthName, ListedON = i.ListedON, OriginalScriptName = i.OriginalScriptName});
            return allInfo;
        }
    }
}
