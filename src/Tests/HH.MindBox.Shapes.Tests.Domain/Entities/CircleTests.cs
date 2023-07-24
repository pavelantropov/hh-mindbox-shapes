using HH.MindBox.Shapes.Domain.Factories;

namespace HH.MindBox.Shapes.Tests.Domain.Entities;

[TestFixture]
public class CircleTests
{
	private IShapeFactory _factory;

	[SetUp]
	public void Setup()
	{
		_factory = new ShapeFactory();
	}

	[TestCase(1)]
	[TestCase(3)]
	[TestCase(4.2)]
	public void Diameter_EqualsDoubleRadius(double radius)
	{
		var circle = _factory.CreateCircle(radius);

		var expected = radius * 2;

		Assert.That(circle.Diameter, Is.EqualTo(expected));
	}

	[TestCase(1)]
	[TestCase(3)]
	[TestCase(4.2)]
	public void GetArea_ReturnsCorrectResult(double radius)
	{
		var circle = _factory.CreateCircle(radius);

		var expected = Math.Pow(radius, 2) * Math.PI;

		Assert.That(circle.GetArea(), Is.EqualTo(expected));
	}
}