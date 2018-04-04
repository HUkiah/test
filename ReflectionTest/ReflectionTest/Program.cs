using ReflectionTest.FactoryTest.EntityClass;
using ReflectionTest.FactoryTest.Interface;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ReflectionTest
{
	[MyCustom("Program1")]
	[MyCustom("han")]
	class Program
	{
		static void Main(string[] args)
		{
			#region Test Code
			//ConsoleManager cm = new ConsoleManager();

			//Log log = new Log(cm);

			//for (int i = 0; i < 10; i++)
			//{
			//	cm.ConsoleOutput("Test Output...{0},{1}，{2}",i,++i,"han");
			//}

			//using (MultiEventClass me = new MultiEventClass()) {
			//	Customer customer = new Customer(me);
			//	me.RiseEvent1();
			//	me.RiseEvent2();
			//}

			//using (Cat cat = new Cat("Tom"))
			//{
			//	Mouse mouse1 = new Mouse("Jerry",cat);
			//	Mouse mousefather = new Mouse("JerryFather", cat);

			//	Master master = new Master("罗田",cat);

			//	cat.CatCry();
			//}
			#endregion

			#region AssemblyTest
			//Assembly assembly = Assembly.LoadFrom(@"..\..\SimpleAssembly\bin\Debug\netcoreapp2.0\SimpleAssembly.dll");
			//AnalyseHelper.AnalyzeAssembly(assembly);

			//// 创建一个程序集中的类型的对象
			//Console.WriteLine("利用反射创建对象");
			//string[] paras = { "测试一下反射效果" };

			//var str = assembly.GetModules()[0].GetTypes()[0].ToString();
			//Console.WriteLine(str);

			//object obj = assembly.CreateInstance(assembly.GetModules()[0].GetTypes()[0].ToString(), true, BindingFlags.CreateInstance, null, paras, null, null);
			//Console.WriteLine(obj);
			#endregion

			#region Attribute
			//IProduct window = FactoryManager.GetProduct(RoomParts.Window);
			//Console.WriteLine("为房子加上了{0}",window.GetName());

			//IProduct roof = FactoryManager.GetProduct(RoomParts.Roof);
			//Console.WriteLine("为房子加上了{0}",roof.GetName());

			//IProduct pillar = FactoryManager.GetProduct(RoomParts.Pillar);
			//Console.WriteLine("为房子加上了{0}",pillar.GetName());

			//IProduct floor = FactoryManager.GetProduct(RoomParts.Floor);
			//Console.WriteLine("为房子加上了{0}", floor.GetName());
			#endregion

			#region AttributeTest



			Type attributeType = typeof(MyCustomAttribute);
			Type thisClass = typeof(Program);

			// 使用IsDefined方法
			bool isDefined = Attribute.IsDefined(thisClass, attributeType);
			Console.WriteLine("Program类是否申明了MyCustomAttribute特性：{0}", isDefined);


			// 使用Attribute.GetCustomAttribute方法
			var att = Attribute.GetCustomAttributes(thisClass, attributeType);
			foreach(var type in att)
			{
				Console.WriteLine("Program类申明了MyCustomAttribute特性，特性的成员为:{0}", (type as MyCustomAttribute).ClassName);
			}


			// 使用CustomAttributeData.GetCustomAttributes方法
			IList<CustomAttributeData> attList = CustomAttributeData.GetCustomAttributes(thisClass);
			if (attList.Count > 0)
			{
				Console.WriteLine("Program类申明了MyCustomAttribute特性");
				// 注意：这里可以对特性进行分析，但无法得到其实例
				CustomAttributeData attData = attList[0];
				Console.WriteLine("该特性的名字是：{0}", attData.Constructor.DeclaringType.Name);
				Console.WriteLine("该特性的构造方法有{0}个参数", attData.ConstructorArguments.Count);
			}

			#endregion

			Console.ReadKey();
		}
	}

	[AttributeUsage(AttributeTargets.Class,AllowMultiple =true)]
	public class MyCustomAttribute : Attribute
	{
		private string className;

		public MyCustomAttribute(string className)
		{
			this.className = className;
		}

		// 一个只读属性ClassName
		public string ClassName
		{
			get
			{
				return className;
			}
		}
	}
}
