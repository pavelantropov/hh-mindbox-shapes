using HH.MindBox.Shapes.Domain.Entities;

namespace HH.MindBox.Shapes.Domain.Factories;

public interface IShapeFactory
{
	Circle CreateCircle (double radius);
	Triangle CreateTriangle (double sideA, double sideB, double sideC);
}