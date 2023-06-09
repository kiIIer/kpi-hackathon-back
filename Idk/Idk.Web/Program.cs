using FluentValidation;
using FluentValidation.AspNetCore;
using Idk.Application.Dtos.Subjects;
using Idk.Application.Dtos.Task;
using Idk.Application.Mapper.Subject;
using Idk.Application.Validation;
using Idk.Domain.Data;
using Idk.Domain.Models;
using Idk.Web.Dependencies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using Idk.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.Register();
builder.Services.AddScoped<IValidator<TaskDto>, TaskDtoValidator>();
builder.Services.AddScoped<IValidator<SubjectDto>, SubjectDtoValidator>();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Idk-backend", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddDbContext<IdkContext>((o) =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("ApplyAll", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}/";
    options.Audience = builder.Configuration["Auth0:Audience"];
    options.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = ClaimTypes.NameIdentifier
    };
});

var app = builder.Build();
app.UseCustomExceptionHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using var scope = app.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;
var recurringJobManager = serviceProvider.GetService<ISubjectMapper>();
try
{
    var a = recurringJobManager.Map(new Subject());
}
catch (Exception e)
{
    Console.WriteLine(e);
}
app.UseHttpsRedirection();
app.UseCors("ApplyAll");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
