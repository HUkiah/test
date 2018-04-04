using ReflectionTest.FactoryTest.Interface;
using System;

namespace ReflectionTest.FactoryTest.EntityClass
{
	[Product(RoomParts.Roof)]
	public class Roof : IProduct
	{
		public string GetName()
		{
			return "屋顶";
		}
	}

	[Product(RoomParts.Window)]
	public class Window : IProduct
	{
		public string GetName()
		{
			return "窗户";
		}
	}

	[Product(RoomParts.Pillar)]
	public class Pillar : IProduct
	{
		public string GetName()
		{
			return "柱子";
		}
	}

	[Product(RoomParts.Floor)]
	public class Floor : IProduct
	{
		public string GetName()
		{
			return "天花板";
		}
	}


	[AttributeUsage(AttributeTargets.Class)]
	public class ProductAttribute : Attribute
	{
		private RoomParts myRoomPart;

		public RoomParts RoomPart => myRoomPart;

		public ProductAttribute(RoomParts parts)
		{
			myRoomPart = parts;
		}
		
	}

}
