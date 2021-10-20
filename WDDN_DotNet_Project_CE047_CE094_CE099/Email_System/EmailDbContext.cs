using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Email_System.Models;

namespace Email_System
{
    public class EmailDbContext:DbContext
    {
        public EmailDbContext():base("name=emaildb")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}