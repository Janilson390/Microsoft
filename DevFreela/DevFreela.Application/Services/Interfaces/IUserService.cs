using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces;

public interface IUserService
{
    List<UserViewModel> GetAll (string query);
    UserDetailsViewModel GetUser (int id);
    int Create(NewUserInputModel inputModel);
    void Update(UpdateUserInputModel inputModel);
    void Delete(int id);    
    void Login(UpdateLoginInputModel inputModel);
}
