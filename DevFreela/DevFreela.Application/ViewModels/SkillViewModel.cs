namespace DevFreela.Application.ViewModels;

public class SkillViewModel
{
    public SkillViewModel(int id, string description, DateTime createdAt) 
    {
        Id = id;
        Description = description;        
        CreatedAt = createdAt;
    }
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
}
