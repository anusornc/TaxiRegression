// MLNetWebApp/Controllers/PredictionController.cs
using Microsoft.AspNetCore.Mvc;
using MLNetWebApp.Models; // หรือ using MLNetWebApp.Models; หากคุณย้ายไฟล์ consumption.cs ไป Models folder
using MLNetWebApp.Services; // สำหรับ PredictionService
using System; // สำหรับ Exception

namespace MLNetWebApp.Controllers // ตรวจสอบ namespace ให้ถูกต้อง
{
    [ApiController] // บอกว่าเป็น API Controller
    [Route("[controller]")] // กำหนด Route สำหรับ Controller นี้ เช่น /Prediction
    public class PredictionController : ControllerBase
    {
        private readonly PredictionService _predictionService;

        // Dependency Injection: ASP.NET Core จะสร้าง PredictionService ให้เรา
        public PredictionController(PredictionService predictionService)
        {
            _predictionService = predictionService;
        }

        [HttpPost("predict-fare")] // กำหนด HTTP Method และ Route สำหรับ Action นี้ เช่น /Prediction/predict-fare
        public ActionResult<float> PredictFare([FromBody] Models.ConsoleApp.SampleRegression.ModelInput input) // รับ ModelInput จาก Request Body (JSON)
        {
            if (input == null)
            {
                return BadRequest("Invalid input data."); // คืนค่า 400 Bad Request ถ้าข้อมูลว่างเปล่า
            }

            try
            {
                float predictedFare = _predictionService.Predict(input); // เรียกใช้ Service เพื่อทำนาย
                return Ok(predictedFare); // คืนค่า 200 OK พร้อมผลลัพธ์
            }
            catch (Exception ex)
            {
                // หากเกิดข้อผิดพลาด ให้คืนค่า 500 Internal Server Error พร้อมข้อความ
                Console.WriteLine($"Error during prediction: {ex.Message}");
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}