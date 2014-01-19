using Microsoft.Phone.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB_WP_Common
{
	public class AgentControl
	{
		public readonly string TaskName = "BatteryCheck";

		private bool isKnowStatus;
		private bool isAgentEnabled;
		public bool IsAgentEnabled
		{
			get
			{
				if (!isKnowStatus)
				{
					var task = ScheduledActionService.Find(TaskName) as PeriodicTask;
					if (task == null)
						isAgentEnabled = false;
					else
						isAgentEnabled = true;
				}

				return isAgentEnabled;
			}
			set
			{
				isKnowStatus = true;
				isAgentEnabled = value;
			}
		}

		public AgentControl()
		{
			isKnowStatus = false;
			isAgentEnabled = false;
		}

		public void StartAgent()
		{
			IsAgentEnabled = true;

			var task = ScheduledActionService.Find(TaskName) as PeriodicTask;

			if (task != null)
				RemoveAgent();

			task = new PeriodicTask(TaskName);
			task.Description = "Update information of battery level";

			// Place the call to Add in a try block in case the user has disabled agents.
			try
			{
				ScheduledActionService.Add(task);

				// If debugging is enabled, use LaunchForTest to launch the agent in one minute.
				#if(DEBUG)
				ScheduledActionService.LaunchForTest(TaskName, TimeSpan.FromSeconds(5));
				#endif
			}
			catch (InvalidOperationException exception)
			{
				if (exception.Message.Contains("BNS Error: The action is disabled"))
				{
					IsAgentEnabled = false;
				}
				if (exception.Message.Contains("BNS Error: The maximum number of ScheduledActions of this type have already been added."))
				{
					// No user action required. The system prompts the user when the hard limit of periodic tasks has been reached.

				}
			}
			catch (SchedulerServiceException)
			{
				// No user action required.
			}

		}

		public void RemoveAgent()
		{
			try
			{
				ScheduledActionService.Remove(TaskName);
				IsAgentEnabled = false;
			}
			catch (Exception)
			{
			}
		}

	}
}
