using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations;

public class SkillService : ISkillService
{
    #region Context
    private readonly DevFreelaDbContext _dbContext; 
    public SkillService(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;        
    }
    #endregion Context

    #region Views
    public List<SkillViewModel> GetAll()
    {
        var skills = _dbContext.Skills;

        var skillViewModel = skills.Select(s => new SkillViewModel(s.Id, s.Description)).ToList();

        return skillViewModel;        
    }
    #endregion Views
}
