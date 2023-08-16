using HH.MindBox.Shapes.Domain.Entities;

namespace HH.MindBox.Shapes.Domain.Factories;

public interface ITriangleFactory 
{
	Task<Triangle> CreateAsync(double sideA, double sideB, double sideC);
}