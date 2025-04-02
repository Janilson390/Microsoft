using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence;

public class DevFreelaDbContext
{
    public DevFreelaDbContext()
    {
        this.Projects = new List<Project>{
        new Project("Meu projeto ASP.NET Core 1","Meu projeto ASP.NET Core 1", 1, 1, 10000),
        new Project("Meu projeto ASP.NET Core 2","Meu projeto ASP.NET Core 2", 1, 1, 20000),
        new Project("Meu projeto ASP.NET Core 3","Meu projeto ASP.NET Core 3", 1, 1, 30000)
        };

        this.Users = new List<User>{
            new User("Janilson Florencio","janilson.silva@teste.com", new DateTime(1987, 5, 25)),
            new User("Maria Silva","silva.maria@unio.com", new DateTime(1993, 11, 23)),
            new User("Jarbas Vasconcelos","jabinha@teste.com", new DateTime(2000, 1, 12))
        };

        this.Skills = new List<Skill>{
            new Skill("ASP.NET Core"),
            new Skill("SQL"),
            new Skill("C#")
        };        
    }
    public List<Project> Projects { get; set; }
    public List<User> Users { get; set; }
    public List<Skill> Skills { get; set; }
}
