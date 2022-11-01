namespace Inheritance;

public class AbstractDaughter : AbstractParent
{
    private readonly double ac;
    private readonly double ab;
    private readonly double bc;
    
    public AbstractDaughter(double ac, double ab, double bc): base("Triangle")
    {
        this.ab = ab;
        this.ac = ac;
        this.bc = bc;
    }

    public override double Perimeter()
    {
        return ab + bc + ac;
    }

    public override double Square()
    {
        // lets image it is square formula
        return ab * bc * ac;
    }

    public override string ToString()
    {
        return name;
    }
}