using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _3_8_23_Assign_22
{
    public class DynamicPropertyMapping
    {
        public void MapProperties(Source source, Destination destination)
        {
            Type sourceType = source.GetType();
            Type destinationType = destination.GetType();

            PropertyInfo[] sourcePropertyInfo = sourceType.GetProperties();
            PropertyInfo[] destinationPropertyInfos = destinationType.GetProperties();

            foreach (PropertyInfo sourceProp in sourcePropertyInfo)
            {
                PropertyInfo destinationProp = Array.Find(destinationPropertyInfos, prop => prop.Name == sourceProp.Name);
                if (destinationProp != null && destinationProp.PropertyType == sourceProp.PropertyType)
                {
                    destinationProp.SetValue(destination, sourceProp.GetValue(source));
                }
            }
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Source source = new Source()
                {
                    Id = 1,
                    Name = "Realme",
                    Product = "C3"

                };

                Destination destination = new Destination()
                {
                    Id = 5,
                    Name = "",
                    Product = "",
                    Price = 10000.00
                };

                Console.WriteLine("Source");
                Console.WriteLine($"ID: {source.Id} Name: {source.Name} Product: {source.Product}");

                Console.WriteLine("\nDestination");
                Console.WriteLine($"ID: {destination.Id} Name: {destination.Name} Product: {destination.Product} Price: {destination.Price}");

                DynamicPropertyMapping mapping = new DynamicPropertyMapping();
                mapping.MapProperties(source, destination);
                Console.WriteLine("\nDestination After mapping");
                Console.WriteLine($"ID: {destination.Id} Name: {destination.Name} Product: {destination.Product} Price: {destination.Price}");

                Console.ReadKey();

            }
        }
    }
}

