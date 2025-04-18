namespace DevFreela.Core.Entities;

public class User :BaseEntity
{
    public User(string fullName, string email, DateTime birthDate)
    {
        this.FullName = fullName;
        this.Email = email;
        this.BirthDate = birthDate;
        Active = true;        
        CreatedAt = DateTime.Now;

        Skills = new List<UserSkill>();   
        OwnedProjects = new List<Project>();
        FreelanceProjects = new List<Project>();        
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool Active { get; private set; }
    public List<UserSkill> Skills { get; private set; }
    public List<Project> OwnedProjects { get; private set; }    
    public List<Project> FreelanceProjects { get; private set; }    
    public List<ProjectComments> Comments { get; private set; }

    public void Inative()
    {
        Active = false;
    }

    public void Update(string email, DateTime birthDate)
    {
        this.Email = email;
        this.BirthDate = birthDate;
    } 

}
