using HH.MindBox.Shapes.Domain.Factories;

namespace HH.MindBox.Shapes.Tests.Domain.Entities;

[TestFixture]
public class CircleTests
{
	private ICircleFactory _factory;

	[SetUp]
	public void Setup()
	{
		_factory = new CircleFactory();
	}

	[TestCase(1)]
	[TestCase(3)]
	[TestCase(4.2)]
	public async Task Diameter_EqualsDoubleRadius(double radius)
	{
		var circle = await _factory.CreateAsync(radius);

		var expected = radius * 2;

		Assert.That(circle.Diameter, Is.EqualTo(expected));
	}

	[TestCase(1)]
	[TestCase(3)]
	[TestCase(4.2)]
	public async Task GetArea_ReturnsCorrectResult(double radius)
	{
		var circle = await _factory.CreateAsync(radius);

		var expected = Math.Pow(radius, 2) * Math.PI;

		Assert.That(circle.CalculateArea(), Is.EqualTo(expected));
	}
}