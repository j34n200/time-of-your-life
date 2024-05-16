using Microsoft.EntityFrameworkCore;
using time_of_your_life.Models;

namespace time_of_your_life.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<ClockProps> ClockProps => Set<ClockProps>();
    }
}
