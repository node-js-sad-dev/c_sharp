namespace Inheritance;

public abstract class AbstractParent
{
    protected string name;

    protected AbstractParent(string name)
    {
        this.name = name;
    }

    public abstract double Perimeter();

    public abstract double Square();
}