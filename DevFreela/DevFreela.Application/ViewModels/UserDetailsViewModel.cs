using DevFreela.Core.Entities;

namespace DevFreela.Application.ViewModels;

public class UserDetailsViewModel
{
    public UserDetailsViewModel(int id, string fullName, string email, DateTime birthDate)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
    }


    public int Id { get; private set;}
    public string FullName { get; private set; }
    public string Email { get; private set;}
    public DateTime BirthDate { get; private set;}
    public List<UserSkill> Skills { get; private set; }
    public List<Project> OwnedProjects { get; private set; }    
    public List<Project> FreelanceProjects { get; private set; }    
}
