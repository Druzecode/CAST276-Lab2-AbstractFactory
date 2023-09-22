using DeviceComponents;
using DeviceComponents.Factories;
using System.Reflection;

namespace DeviceComponentTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestAppleFactory()
        {
            IFactory factory = GetFactory("AppleFactory");
            Assert.IsNotNull(factory);

            IProduct testCase = factory.CreateCase();
            IProduct testCharger = factory.CreateCharger();
            IProduct testScreenProtector = factory.CreateScreenProtector();

            Assert.IsNotNull(testCase);
            Assert.IsNotNull(testCharger);
            Assert.IsNotNull(testScreenProtector);

            Assert.That(testCase.ProductName, Is.EqualTo("Apple case"));
            Assert.That(testCharger.ProductName, Is.EqualTo("Apple charger"));
            Assert.That(testScreenProtector.ProductName, Is.EqualTo("Apple screen protector"));
        }

        [Test]
        public void TestSamsungFactory()
        {
            IFactory factory = GetFactory("SamsungFactory");
            Assert.IsNotNull(factory);

            IProduct testCase = factory.CreateCase();
            IProduct testCharger = factory.CreateCharger();
            IProduct testScreenProtector = factory.CreateScreenProtector();

            Assert.IsNotNull(testCase);
            Assert.IsNotNull(testCharger);
            Assert.IsNotNull(testScreenProtector);

            Assert.That(testCase.ProductName, Is.EqualTo("Samsung case"));
            Assert.That(testCharger.ProductName, Is.EqualTo("Samsung charger"));
            Assert.That(testScreenProtector.ProductName, Is.EqualTo("Samsung screen protector"));
        }

        [Test]
        public void TestGoogleFactory()
        {
            IFactory factory = GetFactory("GoogleFactory");
            Assert.IsNotNull(factory);

            IProduct testCase = factory.CreateCase();
            IProduct testCharger = factory.CreateCharger();
            IProduct testScreenProtector = factory.CreateScreenProtector();

            Assert.IsNotNull(testCase);
            Assert.IsNotNull(testCharger);
            Assert.IsNotNull(testScreenProtector);

            Assert.That(testCase.ProductName, Is.EqualTo("Google case"));
            Assert.That(testCharger.ProductName, Is.EqualTo("Google charger"));
            Assert.That(testScreenProtector.ProductName, Is.EqualTo("Google screen protector"));
        }

        private IFactory GetFactory(string name)
        {
            Assembly devAssembly = System.Reflection.Assembly.Load(new AssemblyName("DeviceComponents"));
            Type factoryType = devAssembly.GetTypes()
                    .Where(type => typeof(IFactory).IsAssignableFrom(type))
                    .Where(type =>
                        !type.IsAbstract &&
                        !type.IsGenericType &&
                        type.GetConstructor(new Type[0]) != null)
                    .FirstOrDefault(t => t.Name.StartsWith(name));

            return factoryType != null ? (IFactory)Activator.CreateInstance(factoryType) : null;
        }
    }
}