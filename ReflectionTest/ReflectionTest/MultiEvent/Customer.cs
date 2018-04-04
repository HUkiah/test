using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionTest.MultiEvent
{
    public class Customer
    {
		public Customer(MultiEventClass events)
		{
			events.Event1 += Event1Handler;
			events.Event2 += Event2Handler;
		}

		private void Event1Handler(object sender, EventArgs e)
		{
			Console.WriteLine("事件一触发！");

		}

		private void Event2Handler(object sender, EventArgs e)
		{
			Console.WriteLine("事件二触发！");

		}
	}
}
