namespace DevFreela.Application.InputModels;

public class UpdateUserInputModel
{
    public UpdateUserInputModel(int id, string email, DateTime birthDate)
    {
        Id = id;
        Email = email;
        BirthDate = birthDate;
    }

    public int Id { get; set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set;}
}
