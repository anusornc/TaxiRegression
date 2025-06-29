// Program.cs
using Microsoft.ML;
using MLNetWebApp;
using MLNetWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton(new MLContext());
builder.Services.AddSingleton<PredictionService>();

// *** ส่วน CORS ที่สำคัญมากสำหรับ Frontend แบบง่ายๆ ***
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin() // อนุญาตให้ทุก Origin เข้าถึงได้ (ง่ายที่สุดสำหรับการทดสอบ)
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
// *** สิ้นสุดส่วน CORS Services ***

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// *** ส่วน CORS Middleware ที่ต้องเรียกใช้ ***
app.UseCors("AllowAllOrigins"); // ใช้ Policy ที่เราตั้งชื่อไว้
// *** สิ้นสุดส่วน CORS Middleware ***

app.MapControllers();

app.Run();