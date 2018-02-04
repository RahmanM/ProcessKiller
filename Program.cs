/*
 * Created by SharpDevelop.
 * User: rahman
 * Date: 25/01/2018
 * Time: 7:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Topshelf;

namespace Killer
{
	class Program
	{
			
		public static void Main(string[] args)
		{
			var rc = HostFactory.Run(x => {    
				                         	
				x.Service<ProcessKiller.ProcessKiller>(s => {                              
					s.ConstructUsing(name => new ProcessKiller.ProcessKiller());           
					s.WhenStarted(tc => tc.Start());                         
					s.WhenStopped(tc => tc.Stop());                          
				});
				x.RunAsLocalSystem();                                      

				x.SetDescription("Rahman Process Killer");                  
				x.SetDisplayName("Rahman Process Killer");                                 
				x.SetServiceName("ProcessKiller");     

				x.StartAutomatically();

			});     	
		}
	}
	
	
	
	
}