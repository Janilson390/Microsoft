using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;

namespace DevFreela.Application.Services.Implementations;

public class UserService : IUserService
{
     #region Context
     private readonly DevFreelaDbContext _dbContext;

     public UserService(DevFreelaDbContext dbContext)
     {
          _dbContext = dbContext;
     }
     #endregion Context

     #region Views
     public List<UserViewModel> GetAll(string query)
     {
          var users = _dbContext.Users;

          var UserViewModel = users
                              .Select(u => new UserViewModel(u.Id, u.FullName, u.Email, u.BirthDate))
                              .ToList();
          return UserViewModel;
     }
     public UserDetailsViewModel GetUser(int id)
     {
          var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);

          if (user == null)
          {
               return null;
          }

          return new UserDetailsViewModel(user.Id, user.FullName, user.Email, user.BirthDate); ;
     }
     #endregion Views

     #region Inputs
     public int Create(NewUserInputModel inputModel)
     {
          var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);

          _dbContext.Users.Add(user);

          return user.Id;
     }
     public void Update(UpdateUserInputModel inputModel)
     {
          var user = _dbContext.Users.SingleOrDefault(u => u.Id == inputModel.Id);

          if (user != null)
          {
               user.Update(inputModel.Email, inputModel.BirthDate);
          }
     }
     public void Delete(int id)
     {
          var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

          user.Inative();
     }
     public void Login(UpdateLoginInputModel inputModel)
     {

     }
     #endregion Inputs
}
