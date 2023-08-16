namespace HH.MindBox.Shapes.Utils;

public interface IValidationHelper
{
	Task ValidateAsync<T>(T value);
}