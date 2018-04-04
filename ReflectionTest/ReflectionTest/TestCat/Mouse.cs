using System;

namespace ReflectionTest.TestCat
{
	public class Mouse
    {
		private string _name { get; set; }

		public string Name => _name;

		public Mouse(string name,Cat cat)
		{
			_name = name;
			cat.CatCryEvent += CatCryEventHandler;
		}

		private void CatCryEventHandler(object sender,CatCryEventArgs e)
		{
			Run();
		}

		private void Run()
		{
			Console.WriteLine("{0}逃走了:溜了溜了！",Name);
		}

    }
}
