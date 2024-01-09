using Microsoft.EntityFrameworkCore;
using soa_blog_api.Data;
using soa_blog_api.Respositories.Implemetation;
using soa_blog_api.Respositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ICategoryResponsitory, CategoryResponsitory>();
builder.Services.AddScoped<IBlogPostResponsitory, BlogPostResponsitory>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsApi",
        builder => builder.WithOrigins("http://localhost:4200", "http://localhost:5000")
            .AllowAnyHeader()
            .AllowAnyMethod());
});
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsApi");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
