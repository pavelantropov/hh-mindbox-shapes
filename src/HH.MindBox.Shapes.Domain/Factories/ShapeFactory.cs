using HH.MindBox.Shapes.Domain.Entities;

namespace HH.MindBox.Shapes.Domain.Factories;

public class ShapeFactory : IShapeFactory
{
	public ShapeFactory() { }

	#region Circle

	public Circle CreateCircle(double radius)
	{
		CheckParamGreaterThanZero(radius, nameof(radius));

		var circle = new Circle(radius);

		return circle;
	}

	#endregion

	#region Triangle

	public Triangle CreateTriangle(double sideA, double sideB, double sideC)
	{
		ValidateTriangleSides(sideA, sideB, sideC);

		var triangle = new Triangle(sideA, sideB, sideC);

		return triangle;
	}

	private void ValidateTriangleSides(double sideA, double sideB, double sideC)
	{
		CheckParamGreaterThanZero(sideA, nameof(sideA));
		CheckParamGreaterThanZero(sideB, nameof(sideB));
		CheckParamGreaterThanZero(sideC, nameof(sideC));

		CheckSideLessThanSumOfAllOtherSides(sideA, nameof(sideA), sideB, sideC);
		CheckSideLessThanSumOfAllOtherSides(sideB, nameof(sideB), sideA, sideC);
		CheckSideLessThanSumOfAllOtherSides(sideC, nameof(sideC), sideA, sideB);
	}

	#endregion

	private void CheckParamGreaterThanZero(double param, string paramName)
	{
		if (param <= 0) throw new ArgumentOutOfRangeException(paramName, $"{paramName} mush be greater than 0.");
	}

	private void CheckSideLessThanSumOfAllOtherSides(double side, string sideName, params double[] otherSides)
	{
		if (side > otherSides.Sum())
		{
			throw new ArgumentOutOfRangeException(sideName, $"{sideName} mush be less than the sum of all the other sides.");
		}
	}
}