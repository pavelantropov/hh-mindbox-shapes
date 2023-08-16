namespace HH.MindBox.Shapes.Domain.Entities;

public class Circle : IShape
{
	public double Radius { get; set; }
	public double Diameter => Radius * 2;

	public Circle(double radius)
	{
		Radius = radius;
	}

	public double CalculateArea() => Math.PI * Math.Pow(Radius, 2);
}