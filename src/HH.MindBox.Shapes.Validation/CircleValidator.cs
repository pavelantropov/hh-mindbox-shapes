using FluentValidation;
using HH.MindBox.Shapes.Domain.Entities;

namespace HH.MindBox.Shapes.Validation;

public class CircleValidator : AbstractValidator<Circle>
{
	public CircleValidator()
	{
		RuleFor(s => s.Radius).GreaterThan(0);
	}
}