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
    public class LoadUsersFromDatabaseController : ControllerBase
    {
        public InformationDBContext _context { get; set; }
        public LoadUsersFromDatabaseController(InformationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<AppUser> LoadUsersFromDatabase()
        {
            var allUserInfo = _context.AppUser;
            return allUserInfo;
        }
    }
}
