using HH.MindBox.Shapes.Api.Model;
using HH.MindBox.Shapes.Domain.Factories;
using HH.MindBox.Shapes.UseCases.Dto;

namespace HH.MindBox.Shapes.UseCases;

public class GetTriangleInfoUseCase : IGetTriangleInfoUseCase
{
	private readonly ITriangleFactory _shapeFactory;

	public GetTriangleInfoUseCase(ITriangleFactory shapeFactory)
	{
		_shapeFactory = shapeFactory;
	}


	public async Task<TriangleInfoDto> Invoke(GetTriangleInfoRequestModel request, CancellationToken cancellationToken)
	{
		return await this.Invoke(request.SideA, request.SideB, request.SideC, cancellationToken);
	}

	public async Task<TriangleInfoDto> Invoke(double sideA, double sideB, double sideC, CancellationToken cancellationToken)
	{
		var triangle = await _shapeFactory.CreateAsync(sideA, sideB, sideC);

		var dto = new TriangleInfoDto
		{
			Area = triangle.CalculateArea(),
			IsRight = triangle.IsRight(),
		};

		return dto;
	}
}