using Microsoft.EntityFrameworkCore;
using PhoneStore5.Models;

namespace PhoneStore5.DataBase
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        public DbSet<PhoneProduct> products { get; set; }

    }
}
