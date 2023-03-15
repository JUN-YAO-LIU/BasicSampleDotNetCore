namespace BasicSample.Application
{
    public class CarService : ICarService
    {
        public string FillingUp(CancellationToken cancellationToken = default)
        {
            return "需要加油";
        }
    }
}