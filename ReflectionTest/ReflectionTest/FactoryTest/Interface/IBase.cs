using ReflectionTest.FactoryTest.EntityClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionTest.FactoryTest.Interface
{

	public enum RoomParts
	{
		Roof,
		Window,
		Pillar,
		Floor
	}

	[ProductList(new Type[] { typeof(Roof),typeof(Window),typeof(Pillar),typeof(Floor) })]
	public interface IProduct
	{
		string GetName();
	}

	public interface IFactory
	{
		IProduct Produce();
	}

	[AttributeUsage(AttributeTargets.Interface)]
	public class ProductListAttribute : Attribute
	{
		private Type[] myList;

		public Type[] ProductList => myList;

		public ProductListAttribute(Type[] products)
		{
			myList = products;
		}
	}


}
