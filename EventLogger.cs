/*
 * Created by SharpDevelop.
 * User: rahman
 * Date: 25/01/2018
 * Time: 7:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
namespace ProcessKiller
{
	public static class EventLogger
	{
		public static void Log(string message)
		{
			const string source = "Rahman Process Killer";
			const string log = "Process Killer";
			
			if (!EventLog.SourceExists(source))
				EventLog.CreateEventSource(source, log);
			
			EventLog.WriteEntry(source, message, EventLogEntryType.Error, 234);
		}
	}
}



