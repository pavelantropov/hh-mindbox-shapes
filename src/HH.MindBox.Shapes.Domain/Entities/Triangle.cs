namespace HH.MindBox.Shapes.Domain.Entities;

public class Triangle : IShape
{
	public double SideA { get; }
	public double SideB { get; }
	public double SideC { get; }
	public double Perimeter => SideA + SideB + SideC;

	public Triangle(double sideA, double sideB, double sideC)
	{
		SideA = sideA;
		SideB = sideB;
		SideC = sideC;
	}

	/// <summary> Является ли прямоугольным </summary>
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

	public double CalculateArea()
	{
		var halfP = Perimeter / 2;

		var area = Math.Sqrt(halfP * (halfP - SideA) * (halfP - SideB) * (halfP - SideC));

		return area;
	}
}