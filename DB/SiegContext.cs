using Microsoft.EntityFrameworkCore;

namespace DB;

public class SiegContext : DbContext
{
    public SiegContext(DbContextOptions<SiegContext> options) : base(options)
    {
    }
    
    public SiegContext() {}

    public DbSet<School> Schools { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Evaluation> Evaluations { get; set; }
    public DbSet<EvaluationItem> EvaluationItems { get; set; }
    public DbSet<Criteria> Criteria { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);

        /*modelBuilder.Entity<School>()
            .HasMany(s => s.Teachers)
            .WithOne(t => t.School)
            .HasForeignKey(t => t.School);*/
        //modelBuilder.Entity<School>().Property<int>("Id").;

        modelBuilder.Seed();
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Console.WriteLine($"Db OnConfiguring: IsConfigured={optionsBuilder.IsConfigured}");
        if (!optionsBuilder.IsConfigured)
        {
            string connctionString = "Server=(LocalDB)\\mssqllocaldb; attachdbfilename=C:\\temp\\Lernsieg.mdf;database=lernsieg;integrated security=True;MultipleActiveResultSets=True";
            Console.WriteLine($"Using connectionString {connctionString}");
            optionsBuilder.UseSqlServer(connctionString);
        }
    }
}