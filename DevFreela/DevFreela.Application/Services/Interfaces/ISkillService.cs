using DevFreela.Application.ViewModels;
using DevFreela.Application.InputModels;

namespace DevFreela.Application.Services.Interfaces;

public interface ISkillService
{
    List<SkillViewModel> GetAll();

    SkillViewModel GetById(int id);

    int Create(NewSkillInputModel inputModel);
}
