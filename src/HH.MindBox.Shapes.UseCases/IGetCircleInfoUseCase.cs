using HH.MindBox.Shapes.Api.Model;
using HH.MindBox.Shapes.UseCases.Dto;

namespace HH.MindBox.Shapes.UseCases;

public interface IGetCircleInfoUseCase
{
	Task<CircleInfoDto> Invoke(
		GetCircleInfoRequestModel request,
		CancellationToken cancellationToken
	);
	Task<CircleInfoDto> Invoke(
		double radius,
		CancellationToken cancellationToken
	);
}
