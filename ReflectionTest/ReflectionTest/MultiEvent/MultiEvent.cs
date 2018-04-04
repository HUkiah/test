using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ReflectionTest.MultiEvent
{
    public partial class MultiEventClass:IDisposable
    {
		private EventHandlerList events;

		public MultiEventClass()
		{
			events = new EventHandlerList();
		}


		public void Dispose()
		{
			events.Dispose();
		}
    }

	public partial class MultiEventClass
	{
		#region event1
		public delegate void Event1Handler(object sender,EventArgs e);

		protected static readonly object Event1Key = new object();

		public event Event1Handler Event1
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				events.AddHandler(Event1Key,value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				events.RemoveHandler(Event1Key, value);
			}
		}

		protected virtual void OnEvent1(EventArgs e)
		{
			events[Event1Key].DynamicInvoke(this, e);
		}

		public void RiseEvent1()
		{
			OnEvent1(EventArgs.Empty);
		}

		#endregion

		#region event2
		public delegate void Event2Handler(object sender, EventArgs e);

		protected static readonly object Event2Key = new object();

		public event Event1Handler Event2
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				events.AddHandler(Event2Key, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				events.RemoveHandler(Event2Key, value);
			}
		}

		protected virtual void OnEvent2(EventArgs e)
		{
			events[Event2Key].DynamicInvoke(this, e);
		}

		public void RiseEvent2()
		{
			OnEvent2(EventArgs.Empty);
		}

		#endregion
	}

}
