namespace Inheritance;

public class DaughterClass : ParentClass
{
    private string name;

    public DaughterClass(int id, string name) : base(id)
    {
        this.name = name;
    }
}