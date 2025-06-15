using ApiFirstProj.AppDbContext;
using ApiFirstProj.Common;
using ApiFirstProj.Entities;
using ApiFirstProj.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>( options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ICommonRepo<Student>, CommonRepo<Student>>();
builder.Services.AddScoped<ICommonRepo<Professor>, CommonRepo<Professor>>();
builder.Services.AddScoped<ICommonRepo<Subject>, CommonRepo<Subject>>();
builder.Services.AddScoped<ICommonRepo<StudentSubject>, CommonRepo<StudentSubject>>();

builder.Services.AddScoped<IStudentServices, StudentServices>();
builder.Services.AddScoped<IProfessorServices, ProfessorServices>();
builder.Services.AddScoped<ISubjectServices, SubjectServices>();
builder.Services.AddScoped<IStudentSubjectServices, StudentSubjectServices>();

// Swagger
builder.Services.AddEndpointsApiExplorer(); // finds all the API routes for documentation
builder.Services.AddSwaggerGen( options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory , "api.xml")); // includes comments in the Swagger doc
}); // generate documentation for API

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseSwagger(); // creates the JSON manual 
app.UseSwaggerUI(); // creates the web page for Swagger

app.UseAuthorization();

app.MapControllers();

app.Run();
