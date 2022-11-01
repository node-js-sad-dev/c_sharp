namespace Inheritance;

public class ParentClass
{
    protected int id;

    public ParentClass(int id)
    {
        this.id = id;
    }

    public int Id
    {
        get => id;
        set => id = value;
    }
}