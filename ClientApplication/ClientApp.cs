using System;
using System.Reflection;
using DeviceComponents;
using DeviceComponents.Factories;

internal class ClientApp
{
    private static IFactory factory;
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the mobile phone accessory store.");
        List<Type> types = GetAllFactories();

        if (types.Count == 0)
        {
            Console.WriteLine("\nNo products were found.  Please check back later!");
        }
        else
        {
            int i = 1;
            foreach (Type t in types)
            {
                Console.WriteLine("\t" + i++ + ": " + t.Name.Replace("Factory", ""));
            }
            Console.WriteLine("\nSelect a product number:");
            char input = Console.ReadKey().KeyChar;
            int selection = 0;
            if (int.TryParse(input.ToString(), out selection))
            {
                selection--; //For 0-based indexing

                if (selection < types.Count && types[selection] != null)
                {
                    Console.WriteLine("\nCreating your products:");
                    factory = (IFactory)Activator.CreateInstance(types[selection]);
                    IProduct myCase = factory.CreateCase();
                    Console.WriteLine("Created: " + myCase.ProductName);
                    IProduct myCharger = factory.CreateCharger();
                    Console.WriteLine("Created: " + myCharger.ProductName);
                    IProduct myScreenProtector = factory.CreateScreenProtector();
                    Console.WriteLine("Created: " + myScreenProtector.ProductName);
                    //IProduct myProtectionPlan = factory.CreateProtectionPlan();
                    //Console.WriteLine("Created: " + myProtectionPlan.ProductName);

                    Console.WriteLine("\nYour products are:");
                    myCase.Draw();
                    myCharger.Draw();
                    myScreenProtector.Draw();
                    //myProtectionPlan.Draw();
                }
                else
                {
                    Console.WriteLine("\nInvalid Selection!");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid Input!");
            }
        }
        Console.WriteLine("\nDone... Press any key to exit");
        Console.ReadKey();
    }


    //Don't worry about understanding the code in this method.  This uses reflection to get all of the classes that implement the IFactory interface.
    //You don't need to alter this.
    private static List<Type> GetAllFactories()
    {
        Assembly devAssembly = System.Reflection.Assembly.Load(new AssemblyName("DeviceComponents"));
        return devAssembly.GetTypes()
                .Where(type => typeof(IFactory).IsAssignableFrom(type))
                .Where(type =>
                    !type.IsAbstract &&
                    !type.IsGenericType &&
                    type.GetConstructor(new Type[0]) != null)
                .ToList();
    }
}