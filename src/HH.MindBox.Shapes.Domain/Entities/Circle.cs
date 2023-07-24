namespace HH.MindBox.Shapes.Domain.Entities;

public class Circle : BaseShape
{
	public double Radius { get; set; }
	public double Diameter => Radius * 2;

	public Circle(double radius)
	{
		Radius = radius;
	}

	public override double GetArea() => Math.PI * Math.Pow(Radius, 2);
}