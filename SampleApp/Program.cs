using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var bus = RPi.I2C.Net.I2CBus.Open("/dev/i2c-1"))
			{
				bus.WriteByte(42, 96);
				byte[] res = bus.ReadBytes(42, 3);
			}
		}
	}
}
