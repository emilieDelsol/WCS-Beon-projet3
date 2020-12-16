using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeOn.Models
{
	public class SelectData
	{
		public static List<EnvironmentPayload> SelectEnvironmentPayloads()
		{
			List<EnvironmentPayload> environmentPayloads = new List<EnvironmentPayload>();
			List<Device> devices = new List<Device>();

			BeOnContext beOnContext = new BeOnContext();
			foreach(EnvironmentPayload environment in beOnContext.EnvironmentPayloads)
			{
				environmentPayloads.Add(environment);
			}
			List<EnvironmentPayload>  environmentPayloadsTest =  environmentPayloads.OrderByDescending(environmentPayloads => environmentPayloads.TimestampEvent).ToList();
			return environmentPayloadsTest;
		}
	}
}
