using ReflectionTest.FactoryTest.Interface;
using System;
using System.Reflection;

namespace ReflectionTest.FactoryTest.EntityClass
{
	#region old Factory Test
	//public class RoofFactory : IFactory
	//{
	//	public IProduct Produce()
	//	{
	//		return new Roof();
	//	}
	//}

	//public class WindowFactory : IFactory
	//{
	//	public IProduct Produce()
	//	{
	//		return new Window();
	//	}
	//}

	//public class PillarFactory : IFactory
	//{
	//	public IProduct Produce()
	//	{
	//		return new Pillar();
	//	}
	//}
	#endregion

	public class Factory
	{
		public IProduct Produce(RoomParts parts)
		{
			ProductListAttribute attr = (ProductListAttribute)Attribute.GetCustomAttribute(typeof(IProduct),typeof(ProductListAttribute));

			foreach (var type in attr.ProductList)
			{
				ProductAttribute pa = (ProductAttribute)Attribute.GetCustomAttribute(type,typeof(ProductAttribute));

				if (pa.RoomPart == parts)
				{
					object product = Assembly.GetExecutingAssembly().CreateInstance(type.FullName);
					return product as IProduct;
				}
			}

			return null;
		}
	}

}
