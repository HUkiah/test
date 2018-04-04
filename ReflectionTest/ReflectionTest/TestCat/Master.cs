using System;

namespace ReflectionTest.TestCat
{
	public class Master
    {
		private string _name { get; set; }

		public string Name => _name;

		public Master(string name,Cat cat)
		{
			_name = name;
			cat.CatCryEvent += CatCryEventHandler;
		}

		private void CatCryEventHandler(object sender,CatCryEventArgs e)
		{
			WakeUp();
		}

		private void WakeUp()
		{
			Console.WriteLine("{0}醒来：起了，起了！",Name);
		}
    }
}
