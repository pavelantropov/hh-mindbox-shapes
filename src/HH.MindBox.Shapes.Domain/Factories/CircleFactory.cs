using FluentValidation;
using HH.MindBox.Shapes.Domain.Entities;

namespace HH.MindBox.Shapes.Domain.Factories;

public class CircleFactory : ICircleFactory
{
	private readonly IValidator<Circle> _validator;

	public CircleFactory(IValidator<Circle> validator)
	{
		_validator = validator;
	}

	public async Task<Circle> CreateAsync(double radius)
	{
		var shape = new Circle(radius);
		await _validator.ValidateAsync(shape);
		return shape;
	}
}