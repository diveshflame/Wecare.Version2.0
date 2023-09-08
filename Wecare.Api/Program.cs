using WeCare.Data.Data.Appointment;
using WeCare.Data.Data.Doctor;
using WeCare.Data.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISqldataAccess, SqldataAccess>();
builder.Services.AddScoped<IAddDoctorData, AddDoctorData>();
builder.Services.AddScoped<IViewAppointment, ViewAppointment>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
