using NIC_Assessment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NIC_Assessment.DB
{
    public class InformationDBContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        //Creating the DBContext for the application
        public InformationDBContext(DbContextOptions<InformationDBContext> options) : base(options)
        {

        }
        public DbSet<Info> Info { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<DateOfBirth> DateOfBirth { get; set; }
        public DbSet<PlaceOfBirth> PlaceOfBirth { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Quality> Quality { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
    }

}
