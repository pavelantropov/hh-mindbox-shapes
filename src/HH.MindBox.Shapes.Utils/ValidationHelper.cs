﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace HH.MindBox.Shapes.Utils;

public class ValidationHelper : IValidationHelper
{
	private readonly IServiceProvider _serviceProvider;

	public ValidationHelper(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	public async Task ValidateAsync<T>(T value)
	{
		var type = typeof(IValidator<>).MakeGenericType(typeof(T));
		var validator = (IValidator)_serviceProvider.GetRequiredService(type);

		var validationContextType = typeof(ValidationContext<>).MakeGenericType(value.GetType());
		var validationContext = (IValidationContext)Activator.CreateInstance(validationContextType, value);

		var result = await validator.ValidateAsync(validationContext);

		if (result.Errors.Any()) { throw new InvalidOperationException(); }
	}
}