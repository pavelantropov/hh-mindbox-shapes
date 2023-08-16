using HH.MindBox.Shapes.Domain.Entities;
using HH.MindBox.Shapes.Domain.Factories;
using HH.MindBox.Shapes.Utils;
using Moq;

namespace HH.MindBox.Shapes.Tests.Domain.Factories;

[TestFixture]
public class CircleFactoryTests
{
	private ICircleFactory _factory;

	[SetUp]
	public void Setup()
	{
		var validatorMock = new Mock<IValidationHelper>();

		_factory = new CircleFactory(validatorMock.Object);
	}

	[TestCase(-1)]
	[TestCase(0)]
	[TestCase(1)]
	public async Task CreateCircle_ValidationError_ThrowsException(double radius)
	{
		var validatorMock = new Mock<IValidationHelper>();
		validatorMock.Setup(m => m.ValidateAsync(It.IsAny<Circle>())).Throws<InvalidOperationException>();
		_factory = new CircleFactory(validatorMock.Object);

		Assert.That(async () => await _factory.CreateAsync(radius), Throws.TypeOf<InvalidOperationException>());
	}

	[TestCase(1)]
	[TestCase(3)]
	[TestCase(4.2)]
	public async Task CreateCircle_GetsValue_ReturnsCorrectObject(double radius)
	{
		var circle = await _factory.CreateAsync(radius);

		Assert.That(circle, Is.InstanceOf<Circle>());
		Assert.That(circle.Radius, Is.EqualTo(radius));
	}
}