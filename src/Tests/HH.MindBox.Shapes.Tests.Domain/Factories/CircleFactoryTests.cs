using HH.MindBox.Shapes.Domain.Factories;

namespace HH.MindBox.Shapes.Tests.Domain.Factories;

[TestFixture]
public class CircleFactoryTests
{
	private ICircleFactory _factory;

	[SetUp]
	public void Setup()
	{
		_factory = new CircleFactory();
	}

	[TestCase(-1)]
	[TestCase(0)]
	public async Task CreateCircle_GetsValueNotGreaterThanZero_ThrowsAOR(double radius)
	{
		Assert.That(async () => await _factory.CreateAsync(radius), Throws.TypeOf<ArgumentOutOfRangeException>());
	}

	[TestCase(1)]
	[TestCase(3)]
	[TestCase(4.2)]
	public async Task CreateCircle_GetsValue_ReturnsCorrectObject(double radius)
	{
		var circle = await _factory.CreateAsync(radius);

		Assert.That(circle.Radius, Is.EqualTo(radius));
	}
}