using ReflectionTest.FactoryTest.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionTest.FactoryTest.EntityClass
{
    public class FactoryManager
    {
		public static IProduct GetProduct(RoomParts parts)
		{
			Factory factory = new Factory();
			IProduct product = factory.Produce(parts);

			Console.WriteLine("生产了 {0} 产品！",product.GetName());

			return product;
		}

    }
}
