namespace DevFreela.Core.Entities;

public class UserSkill :BaseEntity
{
    public UserSkill(int idUser, int idSkill)
    {
        this.IdUser = idUser;
        this.IdSkill = idSkill;
    }

    public int IdUser { get; private set; }
    public int IdSkill { get; private set; }
    public Skill Skill { get; private set; }
}
