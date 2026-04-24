
using QuantumCar.src.Enums;
using QuantumCar.src.Models;

class Programs
{
    public static void Main()
    {
        Console.WriteLine("Testing Gas car..");
        Car gasCar = Factory.CreateCar(EngineType.Gas);
        gasCar.Start();
        gasCar.Accelerate();
        gasCar.Brake();
        gasCar.Stop();

        Console.WriteLine();

        Console.WriteLine("Testing Electric car..");
        Car electricCar = Factory.CreateCar(EngineType.Electric);
        electricCar.Start();
        electricCar.Accelerate();
        electricCar.Brake();
        electricCar.Stop();

        Console.WriteLine();

        Console.WriteLine("Testing Hybrid car..");
        Car hybridCar = Factory.CreateCar(EngineType.Hybrid);
        hybridCar.Start();
        hybridCar.Accelerate();
        hybridCar.Accelerate();
        hybridCar.Accelerate(); // gas

        hybridCar.Brake();
        hybridCar.Brake(); // electric
        hybridCar.Brake();
        
        hybridCar.Stop();

        Console.WriteLine();

        Console.WriteLine("Replacing the Engine");
        Factory.ReplaceEngine(hybridCar, EngineType.Gas); // gas
        Factory.ReplaceEngine(hybridCar, EngineType.Electric); // electric
        hybridCar.Start();
        hybridCar.Stop();
        Factory.ReplaceEngine(hybridCar, EngineType.Hybrid);
        hybridCar.Start();
        hybridCar.Accelerate(); 
        hybridCar.Accelerate(); 
        hybridCar.Accelerate(); 
        hybridCar.Brake();
        hybridCar.Brake();
        hybridCar.Brake();

        hybridCar.Stop();
    }
}
