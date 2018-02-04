/*
 * Created by SharpDevelop.
 * User: rahman
 * Date: 25/01/2018
 * Time: 7:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProcessKiller
{
	public class ServiceConfigurations
	{
		public string ProcessesToKill {
			get;
			set;
		}

		public string LogFolder {
			get;
			set;
		}

		public int PollingFrequencyMilliseconds {
			get;
			set;
		}
	}
}

