using IdentityWithJwtTestProject.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Contexts
{
    public class Context : IdentityDbContext<AppUser, AppRole, string>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
    
        public DbSet<Product> Products { get; set; }
    }    
}
