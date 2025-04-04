namespace DevFreela.Application.ViewModels;

public class ProjectViewModel
{
    public ProjectViewModel(int id, string title, DateTime createdAt)
    {
        this.Id = id;
        this.Title = title;
        this.CreatedAt = createdAt;
    }

    public int Id { get; private set; }
    public string Title { get; private set; }    
    public DateTime CreatedAt { get; private set; }
}
