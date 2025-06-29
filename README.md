# MLNetWebApp: Taxi Fare Prediction with ML.NET

This project demonstrates a complete workflow for building, training, and deploying a machine learning regression model using ML.NET to predict taxi fares. It includes a .NET web API and a simple front-end for making predictions.

## Project Structure

- **MLNetWebApp/**: ASP.NET Core Web API for serving predictions
  - `Controllers/PredictionController.cs`: API endpoint for predictions
  - `Services/PredictionService.cs`: Service for loading and using the ML.NET model
  - `Models/SampleRegression.consumption.cs`: Model input/output classes
  - `SampleRegression.mlnet`: ML.NET Model Builder configuration
  - `Program.cs`: Main entry point
  - `front-end/index.html`: Simple web front-end for predictions
- **SampleRegression/**: ML.NET model training and evaluation code
  - `SampleRegression.training.cs`: Model training logic
  - `SampleRegression.evaluate.cs`: Model evaluation logic
  - `SampleRegression.mlnet`: Model Builder config
  - `SampleRegression.consumption.cs`: Model input/output classes
- **taxi-fare-train.csv**: Example dataset for training

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- (Optional) [Visual Studio](https://visualstudio.microsoft.com/) or VS Code

### Build and Run the Web API

```bash
cd MLNetWebApp
# Restore dependencies
 dotnet restore
# Build the project
 dotnet build
# Run the web API
 dotnet run
```

The API will be available at `https://localhost:5001` or `http://localhost:5000` by default.

### Using the Front-End
Open `MLNetWebApp/front-end/index.html` in your browser. Update the API endpoint in the HTML if needed.

### Training the Model
1. Use ML.NET Model Builder in Visual Studio or run the training code in `SampleRegression/` to retrain the model with your data.
2. Replace the model file in `MLNetWebApp` with the new one if retrained.

## File Descriptions
- `.gitignore`: Ignores build artifacts, user files, data, and ML.NET model files.
- `appsettings.json`: Configuration for the web API.
- `SampleRegression.mlnet` / `.mbconfig`: ML.NET Model Builder configuration files.
- `taxi-fare-train.csv`: Example training data.

## License
This project is for educational and demonstration purposes.
