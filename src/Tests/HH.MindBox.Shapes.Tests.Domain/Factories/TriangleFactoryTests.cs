using HH.MindBox.Shapes.Utils;
using HH.MindBox.Shapes.Domain.Entities;
using HH.MindBox.Shapes.Domain.Factories;
using Moq;

namespace HH.MindBox.Shapes.Tests.Domain.Factories;

[TestFixture]
public class TriangleFactoryTests
{
	private ITriangleFactory _factory;

	[SetUp]
	public void Setup()
	{
		var validatorMock = new Mock<IValidationHelper>();

		_factory = new TriangleFactory(validatorMock.Object);
	}

	[TestCase(-1, 1, 1)]
	[TestCase(1, -1, 1)]
	[TestCase(1, 1, -1)]
	[TestCase(0, 1, 1)]
	[TestCase(1, 0, 1)]
	[TestCase(1, 1, 0)]
	public async Task CreateTriangle_ValidationError_ThrowsException(double sideA, double sideB, double sideC)
	{
		var validatorMock = new Mock<IValidationHelper>();
		validatorMock.Setup(m => m.ValidateAsync(It.IsAny<Triangle>())).Throws<InvalidOperationException>();
		_factory = new TriangleFactory(validatorMock.Object);

		Assert.That(async () => await _factory.CreateAsync(sideA, sideB, sideC), Throws.TypeOf<InvalidOperationException>());
	}

	[TestCase(1, 1, 1)]
	[TestCase(3, 4, 5)]
	[TestCase(4.2, 2, 6)]
	public async Task CreateTriangle_GetsValues_ReturnsCorrectObject(double sideA, double sideB, double sideC)
	{
		var triangle = await _factory.CreateAsync(sideA, sideB, sideC);

		var resultSides = new[] { triangle.SideA, triangle.SideB, triangle.SideC };
		var expectedSides = new[] { sideA, sideB, sideC };

		Assert.That(triangle, Is.InstanceOf<Triangle>());
		CollectionAssert.AreEquivalent(resultSides, expectedSides);
	}
}