using System.Drawing;

public class Flower
{
    public Guid Id {get; set;}
    public string? Name {get; set;}
    public string? Description {get; set;}
    public Color Color {get; set;}
    public decimal Price {get; set;} 
    public virtual ICollection<FlowerBouquet>? FlowerBouquets {get; set;}

}