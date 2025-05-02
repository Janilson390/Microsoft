using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Data.Sqlite;
using DevFreela.Application.InputModels;
using DevFreela.Core.Entities;

namespace DevFreela.Application.Services.Implementations;

public class SkillService : ISkillService
{
    #region Context
    private readonly DevFreelaDbContext _dbContext;
    private readonly string _connectionString;
    public SkillService(DevFreelaDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
    }
    #endregion Context

    #region Views
    public List<SkillViewModel> GetAll()
    {
        var skills = _dbContext.Skills;

        var skillViewModel = skills.Select(s => new SkillViewModel(s.Id, s.Description, s.CreatedAt)).ToList();

        return skillViewModel;
    }

    public SkillViewModel GetById(int id)
    {
        var skill = _dbContext.Skills.SingleOrDefault(s => s.Id == id);

        var skillViewModel = new SkillViewModel(skill.Id, skill.Description, skill.CreatedAt);

        return skillViewModel;
    }
    #endregion Views

    #region Inputs
    public int Create(NewSkillInputModel inputModel)
    {
       var skill = new Skill(inputModel.Description);

        _dbContext.Skills.Add(skill);

        _dbContext.SaveChanges();

        return skill.Id;
    }
    #endregion Inputs
}
