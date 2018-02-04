/*
 * Created by SharpDevelop.
 * User: rahman
 * Date: 25/01/2018
 * Time: 7:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using Nerdle.AutoConfig;
using Polly;
using ProcessKiller;

namespace ProcessKiller
{
	public class ProcessKiller
	{
		private static readonly List<string> ProcessesToKill = new List<string>();

		Timer _timer;

		public ProcessKiller()
		{
			_timer = new Timer(1000) {
				AutoReset = true
			};
			_timer.Elapsed += (sender, eventArgs) => 
				Policy.Handle<Exception>()
				.RetryForever(exception => EventLogger.Log(exception.Message))
				.Execute(() => {
				foreach (var toKill in ProcessesToKill) {
					var processes = Process.GetProcessesByName(toKill);
					foreach (var process in processes) {
						process.Kill();
					}
				}
			});
		}

		public void Start()
		{
			var configs = AutoConfig.Map<ServiceConfigurations>();
			var processNames = configs.ProcessesToKill.Split(',');
			foreach (var processToKill in processNames) {
				ProcessesToKill.Add(processToKill.TrimEnd().TrimStart());
			}
			_timer.Interval = configs.PollingFrequencyMilliseconds;
			_timer.Start();
		}

		public void Stop()
		{
			_timer.Stop();
		}
	}
	
	
}

