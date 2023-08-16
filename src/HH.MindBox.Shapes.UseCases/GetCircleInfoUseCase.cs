using HH.MindBox.Shapes.Api.Model;
using HH.MindBox.Shapes.Domain.Factories;
using HH.MindBox.Shapes.UseCases.Dto;

namespace HH.MindBox.Shapes.UseCases;

public class GetCircleInfoUseCase : IGetCircleInfoUseCase
{
	private readonly ICircleFactory _shapeFactory;

	public GetCircleInfoUseCase(ICircleFactory shapeFactory)
	{
		_shapeFactory = shapeFactory;
	}


	public async Task<CircleInfoDto> Invoke(GetCircleInfoRequestModel request, CancellationToken cancellationToken)
	{
		return await this.Invoke(request.Radius, cancellationToken);
	}

	public async Task<CircleInfoDto> Invoke(double radius, CancellationToken cancellationToken)
	{
		var triangle = await _shapeFactory.CreateAsync(radius);

		var dto = new CircleInfoDto
		{
			Area = triangle.CalculateArea(),
		};

		return dto;
	}
}