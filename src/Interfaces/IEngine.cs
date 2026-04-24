using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumCar.Interfaces
{
    public interface IEngine
    {
        int Speed {  get; }
        void Start();
        void Stop();
        void Increase();
        void Decrease();
        void SpeedChanging(int carSpeed);

    }
}
