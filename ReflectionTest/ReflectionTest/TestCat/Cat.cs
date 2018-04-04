using ReflectionTest.TestCat;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionTest
{
    public class Cat:IDisposable
    {
		private string name;

		public event EventHandler<CatCryEventArgs> CatCryEvent;

		public Cat(string name)
		{
			this.name = name;
		}

		public void CatCry()
		{
			CatCryEventArgs args = new CatCryEventArgs(name);

			CatCryEvent(this,args);

			Console.WriteLine(args);

		}

		public void Dispose()
		{
			
		}
	}
}
