using HH.MindBox.Shapes.Domain.Entities;

namespace HH.MindBox.Shapes.Domain.Factories;

public interface ICircleFactory
{
	Task<Circle> CreateAsync(double radius);
}