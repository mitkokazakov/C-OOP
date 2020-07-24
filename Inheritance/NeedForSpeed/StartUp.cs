namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(300,100);
            Car car = new Car(300,100);

            vehicle.Drive(10);
            car.Drive(10);

            System.Console.WriteLine(vehicle.Fuel);
            System.Console.WriteLine(car.Fuel);
        }
    }
}
