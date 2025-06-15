using ApiFirstProj.AppDbContext;
using ApiFirstProj.Common;
using ApiFirstProj.Entities;
using ApiFirstProj.Services;
using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Asp.Versioning.Conventions;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using ApiFirstProj.Swagger;
using Asp.Versioning.ApiExplorer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Dynamic Swagger Versioning
//builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
//builder.Services.AddSwaggerGen(options =>
//{
//    options.OperationFilter<SwaggerDefaultValues>();
//});


// API versioning -> AddApiVersioning() is the base config for versioning API
builder.Services.AddApiVersioning(config =>
{
    config.AssumeDefaultVersionWhenUnspecified = true; // if the version is not included in the query, default version is selected
    config.DefaultApiVersion = new ApiVersion(1, 0); // this is the default version
    config.ReportApiVersions = true; // tells client the available/deprecated API version (can be seen in Postman Headers response)
    config.ApiVersionReader = new UrlSegmentApiVersionReader(); // tells the Web API to read version from URL

}).AddMvc(options =>
{
    options.Conventions.Add(new VersionByNamespaceConvention()); // tells ASP.NET the version by folder structure, controllers will automatically get version based on folder name ex: v1 , v2_1
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV"; // sets the version shown in Swagger docs,"v" is the prefix and "V" is the version number. eg: v2.1 , v1.1
    options.SubstituteApiVersionInUrl = true; // injects the actual version to {version:apiVersion}
});



// DbContext
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

       // generate documentation for API
builder.Services.AddSwaggerGen( options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory , "api.xml")); // includes comments in the Swagger doc

    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "School Web API", Version = "1.0" });

    options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "School Web API", Version = "2.0" });

});

var app = builder.Build();

// Configure the HTTP request pipeline.

//var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseHttpsRedirection();

app.UseSwagger(); // creates the JSON manual 

// creates the web page for Swagger
app.UseSwaggerUI(options =>
{
    //var descriptions = app.DescribeApiVersions();

    //foreach(var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
    //{
    //    var url = $"/swagger/{description.GroupName}/swagger.json";
    //    var name = description.GroupName.ToUpperInvariant();
    //    options.SwaggerEndpoint(url, name);
    //}

    options.SwaggerEndpoint("/swagger/v1/swagger.json", "1.0");
    options.SwaggerEndpoint("/swagger/v2/swagger.json", "2.0");
}); 

app.UseAuthorization();

app.MapControllers();

app.Run();
