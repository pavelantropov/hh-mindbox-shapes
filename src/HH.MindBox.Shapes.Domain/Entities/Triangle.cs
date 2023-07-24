namespace HH.MindBox.Shapes.Domain.Entities;

public class Triangle : BaseShape
{
	public double SideA { get; set; }
	public double SideB { get; set; }
	public double SideC { get; set; }
	public double Perimeter => SideA + SideB + SideC;

	public Triangle(double sideA, double sideB, double sideC)
	{
		SideA = sideA;
		SideB = sideB;
		SideC = sideC;
	}

	public bool IsRight()
	{
		const double epsilon = 1E-4;

		var sides = new [] { SideA, SideB, SideC };
		Array.Sort(sides);

		var squareA = Math.Pow(sides[0], 2);
		var squareB = Math.Pow(sides[1], 2);
		var squareC = Math.Pow(sides[2], 2);

		return Math.Abs(squareC - squareB - squareA) < epsilon;
	}

	public override double GetArea()
	{
		var halfP = Perimeter / 2;

		var area = Math.Sqrt(halfP * (halfP - SideA) * (halfP - SideB) * (halfP - SideC));

		return area;
	}
}