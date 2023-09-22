namespace DeviceComponents
{
    public class AppleCharger : IProduct
    {
        public string ProductName
        {
            get { return "Apple charger"; }
        }

        public void Draw()
        {
            Console.WriteLine("Drawing an " + ProductName);
        }
    }
}