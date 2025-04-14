using System.Data.Common;
using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities;

public class Project : BaseEntity
{
    public Project(string title, string description, int idClient, int idFreelancer, decimal? totalCost)
    {
        this.Title = title;
        this.Description = description;
        this.IdClient = idClient;
        this.IdFreelancer = idFreelancer;
        this.TotalCost = totalCost;

        CreatedAt = DateTime.Now;  
        Status = ProjectStatusEnum.Created;
        Comments = new List<ProjectComments>();
    }

        public Project(int id, string title, string description, int idClient, int idFreelancer, decimal? totalCost)
        {
        SetId(id);
        this.Title = title;
        this.Description = description;
        this.IdClient = idClient;
        this.IdFreelancer = idFreelancer;
        this.TotalCost = totalCost;

        CreatedAt = DateTime.Now;  
        Status = ProjectStatusEnum.Created;
        Comments = new List<ProjectComments>();
    }



    public string Title { get; private set; }    
    public string Description { get; private set; }    
    public int IdClient { get; private set; }    
    public User Client { get; private set; }
    public int IdFreelancer { get; private set; } 
    public User Freelancer { get; private set; }
    public decimal? TotalCost { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public ProjectStatusEnum Status { get; private set; }
    public List<ProjectComments> Comments { get; private set; }

    public void Cancel()
    { 
        if(this.Status == ProjectStatusEnum.InProgress || this.Status == ProjectStatusEnum.InProgress)
        {   
            this.Status = ProjectStatusEnum.Cancelled;
        }              
    }
    public void Finish()
    { 
        if(this.Status == ProjectStatusEnum.InProgress)
        {
            this.Status = ProjectStatusEnum.Finished; 
            FinishedAt = DateTime.Now;        
        }
    }
    public void Start()
    { 
        if(Status == ProjectStatusEnum.Created)
        {
            this.Status = ProjectStatusEnum.InProgress;             
            StartedAt  = DateTime.Now;           
        }        
    }

    public void Update(string title, string description, decimal totalCost)
    {
        this.Title = title;
        this.Description = description;
        this.TotalCost = totalCost;
    }
}
