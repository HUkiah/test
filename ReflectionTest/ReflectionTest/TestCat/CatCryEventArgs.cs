using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionTest.TestCat
{
    public class CatCryEventArgs:EventArgs
    {
		private string _name { get; set; }

		public string Name => _name;

		public CatCryEventArgs(string name):base()
		{
			_name = name;
		}

		public override string ToString()
		{
			string message = string.Format("{0}叫了",Name);

			return message;
		}
	}
}
