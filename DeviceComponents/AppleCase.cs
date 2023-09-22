namespace DeviceComponents
{
    public class AppleCase : IProduct
    {
        public string ProductName
        {
            get { return "Apple case"; }
        }

        public void Draw()
        {
            Console.WriteLine("Drawing an " + ProductName);
        }
    }
}