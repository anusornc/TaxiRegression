
// This file was auto-generated by ML.NET Model Builder. 

using System;

namespace SampleRegression.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create single instance of sample data from first line of dataset for model input
            SampleRegression.ModelInput sampleData = new SampleRegression.ModelInput()
            {
                Vendor_id = @"CMT",
                Rate_code = 1F,
                Passenger_count = 1F,
                Trip_time_in_secs = 1271F,
                Trip_distance = 3.8F,
                Payment_type = @"CRD",
            };


            Console.WriteLine("Using model to make single prediction -- Comparing actual Fare_amount with predicted Fare_amount from sample data...\n\n");


            Console.WriteLine($"Vendor_id: {@"CMT"}");
            Console.WriteLine($"Rate_code: {1F}");
            Console.WriteLine($"Passenger_count: {1F}");
            Console.WriteLine($"Trip_time_in_secs: {1271F}");
            Console.WriteLine($"Trip_distance: {3.8F}");
            Console.WriteLine($"Payment_type: {@"CRD"}");
            Console.WriteLine($"Fare_amount: {17.5F}");


            // Make a single prediction on the sample data and print results
            var predictionResult = SampleRegression.Predict(sampleData);

            Console.WriteLine($"\n\nPredicted Fare_amount: {predictionResult.Score}\n\n");
            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }
    }
}
