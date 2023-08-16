using HH.MindBox.Shapes.Domain.Entities;
using HH.MindBox.Shapes.Utils;

namespace HH.MindBox.Shapes.Domain.Factories;

public class TriangleFactory : ITriangleFactory
{
	private readonly IValidationHelper _validationHelper;

	public TriangleFactory (IValidationHelper validationHelper)
	{
		_validationHelper = validationHelper;
	}

	public async Task<Triangle> CreateAsync(double sideA, double sideB, double sideC)
	{
		var shape = new Triangle(sideA, sideB, sideC);
		await _validationHelper.ValidateAsync(shape);
		return shape;
	}
}