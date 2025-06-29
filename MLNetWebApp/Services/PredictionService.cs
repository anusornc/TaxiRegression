// Services/PredictionService.cs
using Microsoft.ML;
using System.IO;
using System;
using MLNetWebApp.Models;
using static MLNetWebApp.Models.ConsoleApp.SampleRegression; // หรือ using MLNetWebApp.Models; ถ้าคุณย้ายไฟล์ไป Models folder

namespace MLNetWebApp.Services // ตั้ง namespace ให้ตรงกับตำแหน่งของไฟล์
{
    public class PredictionService
    {
        private readonly MLContext _mlContext;
        private ITransformer _mlModel;
        // ใช้ ModelInput และ ModelOutput ตามที่ CLI สร้างให้และคุณได้ปรับ namespace แล้ว
        private PredictionEngine<ModelInput, ModelOutput> _predictionEngine;

        public PredictionService(MLContext mlContext)
        {
            _mlContext = mlContext;
            LoadModel();
        }

        private void LoadModel()
        {
            // ตรวจสอบให้แน่ใจว่าชื่อไฟล์และเส้นทางถูกต้อง
            // ไฟล์ SampleRegression.mlnet ต้องอยู่ใน Output Directory เดียวกันกับ DLL ของ Web App
            string modelPath = Path.Combine(AppContext.BaseDirectory, "SampleRegression.mlnet");

            if (!File.Exists(modelPath))
            {
                // หากไฟล์ไม่พบ ให้ throw exception เพื่อให้รู้ว่าเกิดอะไรขึ้น
                throw new FileNotFoundException($"Model file not found at: {modelPath}. Ensure 'SampleRegression.mlnet' is set to 'Copy to Output Directory: PreserveNewest' in your .csproj.");
            }

            using (var stream = File.OpenRead(modelPath))
            {
                _mlModel = _mlContext.Model.Load(stream, out var modelInputSchema);
            }

            _predictionEngine = _mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(_mlModel);
            Console.WriteLine("ML.NET model loaded successfully into PredictionService.");
        }

        // เมธอดสำหรับทำนาย - รับ ModelInput และคืนค่า Score
        public float Predict(ModelInput input)
        {
            var prediction = _predictionEngine.Predict(input);
            return prediction.Score; // ดึงค่า Score จาก ModelOutput
        }
    }
}