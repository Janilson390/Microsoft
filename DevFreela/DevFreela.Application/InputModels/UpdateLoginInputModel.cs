namespace DevFreela.Application.InputModels;

public class UpdateLoginInputModel
{
    public UpdateLoginInputModel(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
    
    public string UserName { get; private set; }
    public string Password { get; private set;}
}
