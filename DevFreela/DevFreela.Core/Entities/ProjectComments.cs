namespace DevFreela.Core.Entities;

public class ProjectComments : BaseEntity
{
    public ProjectComments(string content, int idProject, int idUser)
    {
        this.Content = content;
        this.IdProject = idProject;
        this.IdUser = idUser;
        CreatedAt = DateTime.Now;       
    }


    public string Content { get; private set; }
    public int IdProject { get; private set; }
    public Project Project { get; private set; }
    public int IdUser { get; private set; }
    public User User { get; private set; }
    public DateTime CreatedAt { get; private set; }
}
