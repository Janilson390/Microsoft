using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace DevFreela.Application.Services.Implementations;

public class ProjectService : IProjectService
{
    #region Context
    private readonly DevFreelaDbContext _dbContext; 

    public ProjectService(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;        
    }
    #endregion Context

    #region Views    
    public List<ProjectViewModel> GetAll (string query)
    {
        var projects = _dbContext.Projects;

        var projectViewModel = projects
                               .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                               .ToList();
        
        return projectViewModel; 
    }
    public ProjectDetailsViewModel GetById (int id)
    {
        var project = _dbContext.Projects
                        .Include(p => p.Client)
                        .Include(p => p.Freelancer)
                        .SingleOrDefault(p => p.Id == id);

        if (project == null) return null;

        var projectDetailsViewModel = new ProjectDetailsViewModel(project.Id, project.Title, 
                                                                  project.Description, project.TotalCost, 
                                                                  project.CreatedAt, project.FinishedAt,
                                                                  project.Client.FullName, project.Freelancer.FullName);
                                            
        return projectDetailsViewModel;

    }
    #endregion Views

    #region Inputs        
    public int Create(NewProjectInputModel inputModel)
    {
        var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdCliente, inputModel.IdFreelancer, inputModel.TotalCost);

        _dbContext.Projects.Add(project);

        _dbContext.SaveChanges();

        return project.Id;
    }
    public void Update(UpdateProjectInputModel inputModel)
    {
        
        var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

        project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);   

        _dbContext.SaveChanges();     
    }
    public void Delete(int id)
    {
        var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

        project.Cancel();

        _dbContext.SaveChanges();
    }
    public void CreateComment(CreateCommentInputModel inputModel)
    {
        var comment = new ProjectComments(inputModel.Content, inputModel.IdProject, inputModel.IdUser);
        
        _dbContext.ProjectComments.Add(comment);

        _dbContext.SaveChanges();
    }
    public void Start(int id)
    {        
        var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
        
        project.Start();

        _dbContext.SaveChanges();
    }
    public void Finish(int id)
    {
        var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
        
        project.Finish();

        _dbContext.SaveChanges();
    }
    #endregion Inputs
}
