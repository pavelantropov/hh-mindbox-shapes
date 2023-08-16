using System.Reflection;
using System.Text;
using HH.MindBox.Shapes.AutoMapper;
using HH.MindBox.Shapes.Domain.Factories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using FluentValidation;
using HH.MindBox.Shapes.Validation;
using Microsoft.AspNetCore.Mvc;
using HH.MindBox.Shapes.UseCases;
using System.Diagnostics.CodeAnalysis;
using HH.MindBox.Shapes.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IValidationHelper, ValidationHelper>();

builder.Services.AddTransient<ICircleFactory, CircleFactory>();
builder.Services.AddTransient<ITriangleFactory, TriangleFactory>();

builder.Services.AddTransient<IGetCircleInfoUseCase, GetCircleInfoUseCase>();
builder.Services.AddTransient<IGetTriangleInfoUseCase, GetTriangleInfoUseCase>();

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(ShapeMapProfile)));
builder.Services.AddValidatorsFromAssemblyContaining<CircleValidator>();

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(
		b =>
		{
			b.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader();
		});
});

// builder.Services.AddAuthentication(options =>
// 	{
// 		options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
// 		options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// 	})
// 	.AddJwtBearer(options =>
// 	{
// 		options.TokenValidationParameters = new TokenValidationParameters
// 		{
// 			ValidateIssuer = true,
// 			ValidateAudience = true,
// 			ValidateLifetime = true,
// 			ValidateIssuerSigningKey = true,
// 			ValidIssuer = builder.Configuration["Jwt:Issuer"],
// 			ValidAudience = builder.Configuration["Jwt:Issuer"],
// 			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
// 		};
// 	});
// builder.Services.AddAuthorization(options =>
// {
// 	options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
// 	options.AddPolicy("RequireUserRole", policy => policy.RequireRole("User"));
// });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new OpenApiInfo
	{
		Version = "v1",
		Title = "MindBox test task",
		Description = "Shapes App by Pavel Antropov",
		Contact = new OpenApiContact
		{
			Name = "Pavel Antropov",
			Url = new Uri("https://www.linkedin.com/in/pavelantropov/")
		},
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(options => {
		options.SwaggerEndpoint("./swagger/v1/swagger.json", "Shapes App Web Api");
		options.RoutePrefix = string.Empty;
	});
}

app.UseHttpsRedirection();

app.MapGet("/circle", async ([FromQuery][NotNull] double radius, IGetCircleInfoUseCase useCase, CancellationToken cancellationToken) =>
{
	try
	{
		return Results.Ok(await useCase.Invoke(radius, cancellationToken));
	}
	catch (InvalidOperationException ex)
	{
		return Results.BadRequest(ex.Message);
	}
})
.WithName("GetCircleInfo")
.WithOpenApi();

app.MapGet("/triangle", async ([FromQuery][NotNull] double sideA, [FromQuery][NotNull] double sideB, [FromQuery][NotNull] double sideC, 
		IGetTriangleInfoUseCase useCase, CancellationToken cancellationToken) =>
{
	try
	{
		return Results.Ok(await useCase.Invoke(sideA, sideB, sideC, cancellationToken));
	}
	catch (InvalidOperationException ex)
	{
		return Results.BadRequest(ex.Message);
	}
})
.WithName("GetTriangleInfo")
.WithOpenApi();

app.Run();