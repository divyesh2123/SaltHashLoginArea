using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication22.Models
{
    public class CmsDbContext: DbContext
    {
        public DbSet<User> ObjRegisterUser { get; set; }
    }
}