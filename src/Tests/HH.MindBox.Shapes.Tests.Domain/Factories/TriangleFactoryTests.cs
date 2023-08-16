using HH.MindBox.Shapes.Domain.Factories;

namespace HH.MindBox.Shapes.Tests.Domain.Factories;

[TestFixture]
public class TriangleFactoryTests
{
	private ITriangleFactory _factory;

	[SetUp]
	public void Setup()
	{
		_factory = new TriangleFactory();
	}

	[TestCase(-1, 1, 1)]
	[TestCase(1, -1, 1)]
	[TestCase(1, 1, -1)]
	[TestCase(0, 1, 1)]
	[TestCase(1, 0, 1)]
	[TestCase(1, 1, 0)]
	public void CreateTriangle_GetsValueNotGreaterThanZero_ThrowsAOR(double sideA, double sideB, double sideC)
	{
		Assert.That(() => _factory.Create(sideA, sideB, sideC), Throws.TypeOf<ArgumentOutOfRangeException>());
	}

	[TestCase(5, 2, 1)]
	[TestCase(1, 4, 2)]
	[TestCase(3, 3, 8)]
	public void CreateTriangle_GetsSideGreaterThanSumOfOtherSides_ThrowsAOR(double sideA, double sideB, double sideC)
	{
		Assert.That(() => _factory.Create(sideA, sideB, sideC), Throws.TypeOf<ArgumentOutOfRangeException>());
	}

	[TestCase(1, 1, 1)]
	[TestCase(3, 4, 5)]
	[TestCase(4.2, 2, 6)]
	public void CreateTriangle_GetsValues_ReturnsCorrectObject(double sideA, double sideB, double sideC)
	{
		var triangle = _factory.Create(sideA, sideB, sideC);
		
		var resultSides = new[] { triangle.SideA, triangle.SideB, triangle.SideC };
		var expectedSides = new[] { sideA, sideB, sideC };

		CollectionAssert.AreEquivalent(resultSides, expectedSides);
	}
}