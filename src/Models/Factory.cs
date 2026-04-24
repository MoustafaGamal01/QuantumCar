using QuantumCar.src.Enums;
using QuantumCar.src.Models.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumCar.src.Models
{
    internal class Factory
    {
        private static IEngine CreateEngine(EngineType type)
        {
            switch (type)
            {
                case (EngineType.Gas):
                    return new GasEngine();
                case (EngineType.Electric):
                    return new ElectricEngine();
                case (EngineType.Hybrid):
                    return new HybridEngine(new GasEngine(), new ElectricEngine());
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static Car CreateCar(EngineType type)
        {
            Console.WriteLine($"Factory Creating car with type: {type} engine");
            return new Car(CreateEngine(type));
        }
        public static void ReplaceEngine(Car car, EngineType type)
        {
            Console.WriteLine($"Factory Replacing engine with type: {type}");
            car.ReplaceEngine(CreateEngine(type));
        }
    }
}
