using FluentValidation;
using HH.MindBox.Shapes.Domain.Entities;

namespace HH.MindBox.Shapes.Domain.Factories;

public class TriangleFactory : ITriangleFactory
{
	private readonly IValidator<Triangle> _validator;

	public TriangleFactory (IValidator<Triangle> validator)
	{
		_validator = validator;
	}

	public async Task<Triangle> CreateAsync(double sideA, double sideB, double sideC)
	{
		var shape = new Triangle(sideA, sideB, sideC);
		await _validator.ValidateAsync(shape);
		return shape;
	}
}