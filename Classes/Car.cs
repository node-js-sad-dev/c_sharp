namespace Classes;

public class Car
{
    private string brand;

    // public string Brand
    // {
    //     get { return brand; }
    //     private set { brand = value; }
    // }

    public string Brand { get; set; }

    // public string Brand
    // {
    //     get => brand;
    //     set => brand = value;
    // }

    public Car(string brand)
    {
        Brand = brand;
    }
}