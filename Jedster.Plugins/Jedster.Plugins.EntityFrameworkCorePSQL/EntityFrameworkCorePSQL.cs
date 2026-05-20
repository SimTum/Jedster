using Jedster.CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class JedsterContext : DbContext
{
    public JedsterContext (DbContextOptions<JedsterContext> options) :  base (options){ }
    
    public DbSet<Teacher?>?  Teachers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Teacher>()
            .HasKey(teacher => new { teacher.TeacherId });
    }
}