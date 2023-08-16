using FluentValidation;
using HH.MindBox.Shapes.Domain.Entities;

namespace HH.MindBox.Shapes.Validation;

public class TriangleValidator : AbstractValidator<Triangle>
{
	public TriangleValidator()
	{
		RuleFor(s => s.SideA).GreaterThan(0);
		RuleFor(s => s.SideB).GreaterThan(0);
		RuleFor(s => s.SideC).GreaterThan(0);

		RuleFor(s => s.SideA + s.SideB).GreaterThan(s => s.SideC);
		RuleFor(s => s.SideA + s.SideC).GreaterThan(s => s.SideB);
		RuleFor(s => s.SideB + s.SideC).GreaterThan(s => s.SideA);
	}
}