using System;

namespace ReflectionTest
{
	public class ConsoleEventArgs:EventArgs
    {
		private string message { get; set; }

		private object[] _obj { get; set; }

		public string Message => message;

		public object[] Obj => _obj;

		public ConsoleEventArgs(string msg = null,object[] obj=null):base()
		{
			message = msg;

			_obj = obj;

		}

	}
}
