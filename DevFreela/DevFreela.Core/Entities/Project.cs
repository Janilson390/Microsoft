using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities;

public class Project : BaseEntity
{
    public Project(int title, int description, int idCliente, int idFreelancer, decimal? totalCost)
    {
        this.Title = title;
        this.Description = description;
        this.IdCliente = idCliente;
        this.IdFreelancer = idFreelancer;
        this.TotalCost = totalCost;

        CreatedAt = DateTime.Now;  
        Status = ProjectStatusEnum.Created;
        Comments = new List<ProjectComments>();
    }


    public int Title { get; private set; }    
    public int Description { get; private set; }    
    public int IdCliente { get; private set; }    
    public int IdFreelancer { get; private set; } 
    public decimal? TotalCost { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public ProjectStatusEnum Status { get; private set; }
    public List<ProjectComments> Comments { get; private set; }
}
