namespace DeviceComponents
{
    public class AppleScreenProtector : IProduct
    {
        public string ProductName
        {
            get { return "Apple screen protector"; }
        }

        public void Draw()
        {
            Console.WriteLine("Drawing an " + ProductName);
        }
    }
    public class AppleProtectionPlan : IProduct
    {
        public string ProductName
        {
            get { return "Apple protection plan"; }
        }

        public void Draw()
        {
            Console.WriteLine("Drawing an " + ProductName);
        }
    }
}