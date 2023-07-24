using HH.MindBox.Shapes.Domain.Factories;

namespace HH.MindBox.Shapes.Tests.Domain.Entities;

[TestFixture]
public class TriangleTests
{
	private IShapeFactory _factory;

	[SetUp]
	public void Setup()
	{
		_factory = new ShapeFactory();
	}

	[TestCase(1, 1, 1)]
	[TestCase(3, 4, 5)]
	[TestCase(4.2, 2, 6)]
	public void Perimeter_EqualsSumOfAllSides(double sideA, double sideB, double sideC)
	{
		var triangle = _factory.CreateTriangle(sideA, sideB, sideC);

		var expected = sideA + sideB + sideC;

		Assert.That(triangle.Perimeter, Is.EqualTo(expected));
	}

	[TestCase(3, 4, 5)]
	[TestCase(0.6, 0.8, 1)]
	[TestCase(4.2, 5.6, 7)]
	public void IsRight_CalledFromRightTriangle_ReturnsTrue(double sideA, double sideB, double sideC)
	{
		var triangle = _factory.CreateTriangle(sideA, sideB, sideC);

		Assert.That(triangle.IsRight(), Is.True);
	}

	[TestCase(1, 1, 1)]
	[TestCase(3, 4, 3)]
	[TestCase(4.2, 2, 6)]
	public void IsRight_CalledFromObliqueTriangle_ReturnsFalse(double sideA, double sideB, double sideC)
	{
		var triangle = _factory.CreateTriangle(sideA, sideB, sideC);

		Assert.That(triangle.IsRight(), Is.False);
	}

	[TestCase(1, 1, 1)]
	[TestCase(3, 4, 5)]
	[TestCase(4.2, 2, 6)]
	public void GetArea_ReturnsCorrectResult(double sideA, double sideB, double sideC)
	{
		var triangle = _factory.CreateTriangle(sideA, sideB, sideC);

		var halfP = triangle.Perimeter / 2;
		var expected = Math.Sqrt(halfP * (halfP - sideA) * (halfP - sideB) * (halfP - sideC));

		Assert.That(triangle.GetArea(), Is.EqualTo(expected));
	}
}