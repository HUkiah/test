//using System;
//using System.IO;
//using System.Text;

//namespace ReflectionTest {

//	public enum LogType
//	{
//		Debug,
//		Trace,
//		Info,
//		Warn,
//		Error
//	}

//	public delegate void Log(string content, LogType type);

//	public sealed partial class LogManager : IDisposable
//	{
//		private Type _componentType;
//		private String _logfile;
//		private FileStream _fs;
//		public Log WriteLog;         //用来写日志的委托
//									 //锁
//		private static object mutext = new object();
//		//严格控制无参的构造方法
//		private LogManager()
//		{
//			WriteLog = new Log(PrepareLogFile);
//			WriteLog += OpenStream; //打开流
//			WriteLog += AppendLocalTime;    //添加本地时间
//			WriteLog += AppendSeperator;    //添加分隔符
//			WriteLog += AppendComponentType;//添加模块类别
//			WriteLog += AppendSeperator;    //添加分隔符
//			WriteLog += AppendType;         //添加日志类别
//			WriteLog += AppendSeperator;    //添加分隔符
//			WriteLog += AppendContent;      //添加内容
//			WriteLog += AppendNewLine;      //添加回车
//			WriteLog += CloseStream;        //关闭流
//		}
//		/// <summary>
//		/// 构造方法
//		/// </summary>
//		/// <param name="type">使用该日志的类型</param>
//		/// <param name="file">日志文件全路径</param>
//		public LogManager(Type type, String file) : this()
//		{
//			_logfile = file;
//			_componentType = type;

//		}
//		/// <summary>
//		/// 释放FileStream对象
//		/// </summary>
//		public void Dispose()
//		{
//			if (_fs != null)
//				_fs.Dispose();
//			GC.SuppressFinalize(this);
//		}
//		~LogManager()
//		{
//			if (_fs != null)
//				_fs.Dispose();
//		}

//	}

//	/// <summary>
//	/// 委托链上的方法（和日志文件有关的操作）
//	/// </summary>
//	public sealed partial class LogManager : IDisposable
//	{
//		/// <summary>
//		/// 如果日志文件不存在，则新建日志文件
//		/// </summary>
//		private void PrepareLogFile(String content, LogType type)
//		{
//			//只允许单线程创建日志文件
//			lock (mutext)
//			{
//				if (!File.Exists(_logfile))
//					using (FileStream fs = File.Create(_logfile))
//					{ }
//			}
//		}
//		/// <summary>
//		/// 打开文件流
//		/// </summary>
//		private void OpenStream(String content, LogType type)
//		{
//			_fs = File.Open(_logfile, FileMode.Append);
//		}
//		/// <summary>
//		/// 关闭文件流
//		/// </summary>
//		private void CloseStream(String content, LogType type)
//		{
//			_fs.Close();
//			_fs.Dispose();
//		}
//	}

//	/// <summary>
//	/// 委托链上的方法（和日志时间有关的操作）
//	/// </summary>
//	public sealed partial class LogManager : IDisposable
//	{
//		/// <summary>
//		/// 为日志添加当前UTC时间
//		/// </summary>
//		private void AppendUTCTime(String content, LogType type)
//		{
//			String time = DateTime.Now.ToUniversalTime().ToString();
//			Byte[] con = Encoding.Default.GetBytes(time);
//			_fs.Write(con, 0, con.Length);
//		}
//		/// <summary>
//		/// 为日志添加本地时间
//		/// </summary>
//		private void AppendLocalTime(String content, LogType type)
//		{
//			String time = DateTime.Now.ToLocalTime().ToString();
//			Byte[] con = Encoding.Default.GetBytes(time);
//			_fs.Write(con, 0, con.Length);
//		}
//	}

//	/// <summary>
//	/// 委托链上的方法（和日志内容有关的操作）
//	/// </summary>
//	public sealed partial class LogManager : IDisposable
//	{
//		/// <summary>
//		/// 添加日志内容
//		/// </summary>
//		private void AppendContent(String content, LogType type)
//		{
//			Byte[] con = Encoding.Default.GetBytes(content);
//			_fs.Write(con, 0, con.Length);
//		}
//		/// <summary>
//		/// 为日志添加组件类型
//		/// </summary>
//		private void AppendComponentType(String content, LogType type)
//		{
//			Byte[] con = Encoding.Default.GetBytes(_componentType.ToString());
//			_fs.Write(con, 0, con.Length);
//		}
//		/// <summary>
//		/// 添加日志类型
//		/// </summary>
//		private void AppendType(String content, LogType type)
//		{
//			String typestring = String.Empty;
//			switch (type)
//			{
//				case LogType.Debug:
//					typestring = "Debug";
//					break;
//				case LogType.Error:
//					typestring = "Error";
//					break;
//				case LogType.Info:
//					typestring = "Info";
//					break;
//				case LogType.Trace:
//					typestring = "Trace";
//					break;
//				case LogType.Warn:
//					typestring = "Warn";
//					break;
//				default:
//					typestring = "";
//					break;
//			}
//			Byte[] con = Encoding.Default.GetBytes(typestring);
//			_fs.Write(con, 0, con.Length);
//		}
//	}

//	/// <summary>
//	/// 委托链上的方法（和日志的格式控制有关的操作）
//	/// </summary>
//	public sealed partial class LogManager : IDisposable
//	{

//		/// <summary>
//		/// 添加分隔符
//		/// </summary>
//		private void AppendSeperator(String content, LogType type)
//		{
//			Byte[] con = Encoding.Default.GetBytes(" | ");
//			_fs.Write(con, 0, con.Length);
//		}
//		/// <summary>
//		/// 添加换行符
//		/// </summary>
//		private void AppendNewLine(String content, LogType type)
//		{
//			Byte[] con = Encoding.Default.GetBytes("\r\n");
//			_fs.Write(con, 0, con.Length);
//		}
//	}

//	/// <summary>
//	/// 修改所使用的时间类型
//	/// </summary>
//	public sealed partial class LogManager : IDisposable
//	{
//		/// <summary>
//		/// 设置使用UTC时间
//		/// </summary>
//		public void UseUTCTime()
//		{
//			WriteLog = new Log(PrepareLogFile);
//			WriteLog += OpenStream;
//			WriteLog += AppendUTCTime;
//			WriteLog += AppendSeperator;
//			WriteLog += AppendComponentType;
//			WriteLog += AppendSeperator;
//			WriteLog += AppendType;
//			WriteLog += AppendSeperator;
//			WriteLog += AppendContent;
//			WriteLog += AppendNewLine;
//			WriteLog += CloseStream;
//		}
//		/// <summary>
//		/// 设置使用本地时间
//		/// </summary>
//		public void UseLocalTime()
//		{
//			WriteLog = new Log(PrepareLogFile);
//			WriteLog += OpenStream;
//			WriteLog += AppendLocalTime;
//			WriteLog += AppendSeperator;
//			WriteLog += AppendComponentType;
//			WriteLog += AppendSeperator;
//			WriteLog += AppendType;
//			WriteLog += AppendSeperator;
//			WriteLog += AppendContent;
//			WriteLog += AppendNewLine;
//			WriteLog += CloseStream;
//		}
//	}
//}