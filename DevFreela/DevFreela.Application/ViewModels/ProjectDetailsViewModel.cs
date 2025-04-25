using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.Application.ViewModels;

public class ProjectDetailsViewModel
{
    private decimal? totalCost;

    public ProjectDetailsViewModel( int id, string title, string description, decimal? totalCost, 
                                    DateTime createdAt, DateTime? finishedAt, string clienteFullName, string freelancerFullName)
    {
        Id = id;
        Title = title;
        Description = description;
        this.totalCost = totalCost;
        CreatedAt = createdAt;
        FinishedAt = finishedAt;
        ClienteFullName = clienteFullName;
        FreelancerFullName = freelancerFullName;
    }

    public int Id { get; private set; }    
    public string Title { get; private set; }    
    public string Description { get; private set; }    
    public decimal TotalCost { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public string ClienteFullName { get; private set; }
    public string FreelancerFullName { get; private set; }
    public ProjectStatusEnum Status { get; private set; }
    public List<ProjectComments> Comments { get; private set; }

}
