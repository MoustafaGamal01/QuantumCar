using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumCar.src.Models
{
    public class Car
    {
        private const int _maxSpeed = 200;
        private IEngine _engine;
        private bool _carIsWorking;
        public int _carSpeed => _engine.Speed;
        public Car(IEngine engine)
        {
            _engine = engine;
            _carIsWorking = false;
        }


        public void Start()
        {
            if (_carIsWorking)
            {
                Console.WriteLine("The car is already working.");
                return;
            }
            _engine.Start();
            _carIsWorking = true;
            Console.WriteLine($"The car is statred with Speed {_carSpeed}");
        }

        public void Stop()
        {
            if (!_carIsWorking)
            {
                Console.WriteLine("The car already stopped");
                return;
            }

            if (_carSpeed != 0)
            {
                Console.WriteLine("Can't stop, brake first");
                return;
            }
            _engine.Stop();
            _carIsWorking = false;
            Console.WriteLine("The car stopped");
        }

        public void Accelerate()
        {
            if (!_carIsWorking)
            {
                Console.WriteLine("The car is not working");
                return;
            }

            if (_carSpeed >= _maxSpeed)
            {
                Console.WriteLine("Already at max speed");
                return;
            }

            int newSpeed = Math.Min(_carSpeed + 20, _maxSpeed);
            int toBeIncreased = newSpeed - _carSpeed;

            while (toBeIncreased > 0)
            {
                _engine.Increase();
                toBeIncreased--;
            }
            _engine.SpeedChanging(_carSpeed);
            Console.WriteLine($"Accelerated {_carSpeed} km/h");
        }

        public void Brake()
        {
            if (!_carIsWorking)
            {
                Console.WriteLine("The car is not working");
                return;
            }

            if (_carSpeed <= 0)
            {
                Console.WriteLine("Already Stopped");
                return;
            }

            int newSpeed = Math.Max(_carSpeed - 20, 0);
            int toBeDecreased = newSpeed - _carSpeed;

            while (toBeDecreased > 0)
            {
                _engine.Decrease();
                toBeDecreased--;
            }
            _engine.SpeedChanging(_carSpeed);
            Console.WriteLine($"Braked {_carSpeed} km/h");
        }

        public void ReplaceEngine(IEngine newEngine)
        {
            if (_carIsWorking)
            {
                Console.WriteLine("Stop the car first");
                return;
            }
            _engine = newEngine;
            Console.WriteLine("Car Engine replaced");
        }

    }
}
