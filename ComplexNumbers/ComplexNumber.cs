using System.Runtime.CompilerServices;

namespace ComplexNumbers;

public class ComplexNumber
{
    private double Material { get; set; }
    private double Imaginary { get; set; }

    public ComplexNumber(double material, double imaginary)
    {
        Material = material;
        Imaginary = imaginary;
    }

    public ComplexNumber Plus(ComplexNumber complexNumber)
    {
        var newMaterial = Material + complexNumber.Material;
        var newImaginary = Imaginary + complexNumber.Imaginary;

        return new ComplexNumber(newMaterial, newImaginary);
    }
    
    public ComplexNumber Minus(ComplexNumber complexNumber)
    {
        var newMaterial = Material - complexNumber.Material;
        var newImaginary = Imaginary - complexNumber.Imaginary;

        return new ComplexNumber(newMaterial, newImaginary);
    }
    
    public override string ToString()
    {
        return $"Material = {Material}, Imaginary = {Imaginary}";
    }
}