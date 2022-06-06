using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MedManager.Models
{
    public class MedManagerContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext
    {
        
        public MedManagerContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<MedTakeModel> Take { get; set; }
    }

}
