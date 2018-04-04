using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionTest.Event
{
    public class ConsoleManager
    {
		public event EventHandler<ConsoleEventArgs> ConsoleEvent;

		public void ConsoleOutput(string message, params object[] obj)
		{
			ConsoleEventArgs args = new ConsoleEventArgs(message,obj);
			SendConsoleEvent(args);

			Console.WriteLine(message,obj);

		}

		protected virtual void SendConsoleEvent(ConsoleEventArgs args)
		{
			ConsoleEvent?.Invoke(this, args);
		}
    }
}
