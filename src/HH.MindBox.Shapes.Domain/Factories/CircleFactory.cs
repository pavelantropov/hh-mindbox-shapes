using HH.MindBox.Shapes.Domain.Entities;
using HH.MindBox.Shapes.Utils;

namespace HH.MindBox.Shapes.Domain.Factories;

public class CircleFactory : ICircleFactory
{
	private readonly IValidationHelper _validationHelper;

	public CircleFactory(IValidationHelper validationHelper)
	{
		_validationHelper = validationHelper;
	}

	public async Task<Circle> CreateAsync(double radius)
	{
		var shape = new Circle(radius);
		await _validationHelper.ValidateAsync(shape);
		return shape;
	}
}