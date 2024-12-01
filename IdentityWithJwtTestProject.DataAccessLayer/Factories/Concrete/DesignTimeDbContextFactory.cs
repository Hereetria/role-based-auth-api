using IdentityWithJwtTestProject.DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Factories.Concrete
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();

            var connectionString = @"Server=DESKTOP-A7AFDHF\SQLEXPRESS;Initial Catalog=IdentityWithJwtProject;Integrated Security=true;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connectionString);

            return new Context(optionsBuilder.Options);
        }
    }
}
