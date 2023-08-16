using HH.MindBox.Shapes.Api.Model;
using HH.MindBox.Shapes.UseCases.Dto;

namespace HH.MindBox.Shapes.UseCases;

public interface IGetTriangleInfoUseCase
{
	Task<TriangleInfoDto> Invoke(
		GetTriangleInfoRequestModel request,
		CancellationToken cancellationToken
	);
	Task<TriangleInfoDto> Invoke(
		double sideA,
		double sideB,
		double sideC,
		CancellationToken cancellationToken
	);
}
