namespace DevFreela.Application.InputModels;

public class UpdateUserInputModel
{
    public int Id { get; set; }
    public string FullName { get; private set;}
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set;}
}
