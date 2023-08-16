using HH.MindBox.Shapes.Domain.Factories;

namespace HH.MindBox.Shapes.Tests.Domain.Entities;

[TestFixture]
public class TriangleTests
{
	private ITriangleFactory _factory;

	[SetUp]
	public void Setup()
	{
		_factory = new TriangleFactory();
	}

	[TestCase(1, 1, 1)]
	[TestCase(3, 4, 5)]
	[TestCase(4.2, 2, 6)]
	public async Task Perimeter_EqualsSumOfAllSides(double sideA, double sideB, double sideC)
	{
		var triangle = await _factory.CreateAsync(sideA, sideB, sideC);

		var expected = sideA + sideB + sideC;

		Assert.That(triangle.Perimeter, Is.EqualTo(expected));
	}

	[TestCase(3, 4, 5)]
	[TestCase(0.6, 0.8, 1)]
	[TestCase(4.2, 5.6, 7)]
	public async Task IsRight_CalledFromRightTriangle_ReturnsTrue(double sideA, double sideB, double sideC)
	{
		var triangle = await _factory.CreateAsync(sideA, sideB, sideC);

		Assert.That(triangle.IsRight(), Is.True);
	}

	[TestCase(1, 1, 1)]
	[TestCase(3, 4, 3)]
	[TestCase(4.2, 2, 6)]
	public async Task IsRight_CalledFromObliqueTriangle_ReturnsFalse(double sideA, double sideB, double sideC)
	{
		var triangle = await _factory.CreateAsync(sideA, sideB, sideC);

		Assert.That(triangle.IsRight(), Is.False);
	}

	[TestCase(1, 1, 1)]
	[TestCase(3, 4, 5)]
	[TestCase(4.2, 2, 6)]
	public async Task GetArea_ReturnsCorrectResult(double sideA, double sideB, double sideC)
	{
		var triangle = await _factory.CreateAsync(sideA, sideB, sideC);

		var halfP = triangle.Perimeter / 2;
		var expected = Math.Sqrt(halfP * (halfP - sideA) * (halfP - sideB) * (halfP - sideC));

		Assert.That(triangle.CalculateArea(), Is.EqualTo(expected));
	}
}