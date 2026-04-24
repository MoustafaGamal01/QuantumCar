global using QuantumCar.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumCar.src.Models.Engine
{
    internal class GasEngine : IEngine
    {
        public int Speed {get; private set;}

        public void Decrease()
        {
            if (Speed > 0)
            {
                Speed -= 1;
            }
        }

        public void Increase()
        {
            Speed += 1;
        }

        public void SpeedChanging(int carSpeed)
        {
            if (Speed < 0)
            {
                Console.WriteLine("Invalid speed. Speed cannot be negative.");
                return;
            }
            Speed = carSpeed;
        }

        public void Start()
        {
            Speed = 0;
        }

        public void Stop()
        {
            Speed = 0;
        }
    }
}
