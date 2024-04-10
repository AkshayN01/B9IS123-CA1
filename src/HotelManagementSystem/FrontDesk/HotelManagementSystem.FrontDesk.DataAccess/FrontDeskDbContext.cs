using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.FrontDesk.DataAccess
{
    public class FrontDeskDbContext : DbContext
    {
        public FrontDeskDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
    }
}
