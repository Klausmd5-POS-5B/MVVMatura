using Microsoft.EntityFrameworkCore;

namespace DB;

public static class Spostsieder
{
    public static void Seed(this ModelBuilder mb)
    {
        File.ReadAllLines("schools.csv")
            .Select(line => line.Split(";"))
            .Select(values => new School
            {
                Id = int.Parse(values[0]),
                Name = values[1],
                Country = "AT",
                SchoolNumber = int.Parse(values[0]),
                Address = values[2]
            })
            .ToList()
            .ForEach(school => mb.Entity<School>().HasData(school));
        
        Console.WriteLine($"Schools seeded");

        File.ReadAllLines("teachers.csv").Skip(1).Select(x => x.Split(";")).Select(x => new Teacher()
        {
            Id = new Random().Next(),
            Name = x[0],
            Title = x[1],
            SchoolId = int.Parse(x[2])
        }).ToList().ForEach(t => mb.Entity<Teacher>().HasData(t));

        Console.WriteLine($"Teachers seeded");
    }
}