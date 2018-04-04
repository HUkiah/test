using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReflectionTest.Event
{
    public class Log
    {
		private const string logFile = @"D:\TestLog.txt";
		delegate string strReplace(string str, object[] obj);

		public Log(ConsoleManager cm)
		{
			cm.ConsoleEvent += this.WriteLog;
		}

		private void WriteLog(object sender,EventArgs args)
		{
			if (!File.Exists(logFile))
			{
				using (FileStream fs = File.Create(logFile)) { }
			}

			FileInfo fi = new FileInfo(logFile);

			using (StreamWriter sw = fi.AppendText())
			{
				ConsoleEventArgs cea = args as ConsoleEventArgs;

				strReplace Sr1 = (msg, obj) =>
				{
					for (int i = 0; i < obj.Length; i++)
					{
					   msg = msg.Replace("{" + i + "}", obj[i].ToString());
					}
					return msg;
				};

				sw.WriteLine(DateTime.Now.ToString("G")+"|"+sender.ToString()+"|"+ Sr1(cea.Message,cea.Obj));
			}
		}
    }
}
