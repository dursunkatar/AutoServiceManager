using Microsoft.EntityFrameworkCore;
using OtoServis.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.DataAccess
{
    public static class DbContextBuilder
    {
        public static AppDbContext Build()
        {
            return new AppDbContext(new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(ConnectionString.Value).Options);
        }
    }
}
