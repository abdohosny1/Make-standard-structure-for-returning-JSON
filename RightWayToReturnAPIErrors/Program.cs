using Microsoft.AspNetCore.Http.Features;
using RightWayToReturnAPIErrors.Error;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddProblemDetails(option =>
{
    option.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Instance = $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";
        context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);

        var activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
        context.ProblemDetails.Extensions.TryAdd("traceId", activity?.Id);
    };
});

builder.Services.AddExceptionHandler<ProblemExpectionHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/weather", (string city, string units) =>
{
    // Logic to fetch weather for the specified city and units
    // Example response, you can replace with actual weather logic
    var weatherInfo = new
    {
        City = city,
        Units = units,
        Temperature = "22°C", // Example value
        Condition = "Clear sky"
    };

    var degree_unit = units switch
    {
        "c" =>"metric",
        "f"=>"imperial",
        "k"=>"standrad",
        _=>"invalid"
    };

    if(degree_unit == "invalid")
    {
        //return Results.Problem(
        //    type: "bad request", 
        //    title: "Invalid Units",
        //    detail: "Units can only be c,f,k",
        //    statusCode: StatusCodes.Status400BadRequest);

        throw new ProblemExpection("Invalid Units", "Units can only be c,f,k");
    }

    return Results.Ok(weatherInfo);
});

app.Run();
