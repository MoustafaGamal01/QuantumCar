
namespace QuantumCar.src.Models.Engine
{
    internal class HybridEngine : IEngine
    {
        private readonly IEngine _gas;
        private readonly IEngine _electric;
        private IEngine _working;

        public int Speed => _working.Speed;

        public HybridEngine(IEngine gas, IEngine electric)
        {
            _gas = gas;
            _electric = electric;
            _working = _electric;
        }

        public void Start()
        {
            _working = _electric;
            _working.Start();
            Console.WriteLine("Hybrid Engine Started (Electric).");
        }

        public void Stop()
        {
            _working.Stop();
            Console.WriteLine("Hybrid Engine Stopped.");
        }

        public void Increase() => _working.Increase();
        public void Decrease() => _working.Decrease();
        public void SpeedChanging(int carSpeed)
        {
            if(carSpeed < 0)
            {
                Console.WriteLine("Invalid speed. Speed cannot be negative.");
                return;
            }

            IEngine target = carSpeed < 50 ? _electric : _gas;

            if (!ReferenceEquals(_working, target))
            {
                string from = ReferenceEquals(_working, _gas) ? "Gas" : "Electric";
                string to = ReferenceEquals(target, _gas) ? "Gas" : "Electric";

                _working.Stop();
                _working = target;
                _working.Start();
                Console.WriteLine($"Hybrid is now ({to}), and the speed {carSpeed} km/h");
            }

            _working.SpeedChanging(carSpeed);
        }
    }
}
