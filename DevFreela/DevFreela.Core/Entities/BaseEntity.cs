namespace DevFreela.Core.Entities;

public abstract class BaseEntity
{
    protected BaseEntity() 
    {
        
    }       
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }
}
