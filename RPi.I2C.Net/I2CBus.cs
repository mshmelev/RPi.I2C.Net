using System;
using System.IO;
using System.Text;
using Mono.Unix;
using Mono.Unix.Native;

namespace RPi.I2C.Net
{
	public class I2CBus : II2CBus, IDisposable
	{
		private int busHandle;


		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="busPath"></param>
		protected I2CBus(string busPath)
		{
			int res= I2CNativeLib.OpenBus(busPath);
			if (res< 0)
				throw new IOException(String.Format("Error opening bus '{0}': {1}", busPath, UnixMarshal.GetErrorDescription(Stdlib.GetLastError())));
			
			busHandle = res;
		}


		/// <summary>
		/// Creates new instance of I2CBus.
		/// </summary>
		/// <param name="busPath">Path to system file associated with I2C bus.<br/>
		/// For RPi rev.1 it's usually "/dev/i2c-0",<br/>
		/// For rev.2 it's "/dev/i2c-1".</param>
		/// <returns></returns>
		public static I2CBus Open(string busPath)
		{
			return new I2CBus(busPath);
		}



		public void Finalyze()
		{
			Dispose(false);
		}



		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}



		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				// disposing managed resouces
			}

			if (busHandle != 0)
			{
				I2CNativeLib.CloseBus(busHandle);
				busHandle = 0;
			}
		}


		/// <summary>
		/// Writes single byte.
		/// </summary>
		/// <param name="address">Address of a destination device</param>
		/// <param name="b"></param>
		public void WriteByte(int address, byte b)
		{
			byte[] bytes= new byte[1];
			bytes[0] = b;
			WriteBytes(address, bytes);
		}


		/// <summary>
		/// Writes array of bytes.
		/// </summary>
		/// <param name="address">Address of a destination device</param>
		/// <param name="bytes"></param>
		public void WriteBytes(int address, byte[] bytes)
		{
			int res= I2CNativeLib.WriteBytes(busHandle, address, bytes, bytes.Length);
			if (res== -1)
				throw new IOException(String.Format("Error accessing address '{0}': {1}", address, UnixMarshal.GetErrorDescription(Stdlib.GetLastError())));
			if (res== -2)
				throw new IOException(String.Format("Error writing to address '{0}': {1}", address, UnixMarshal.GetErrorDescription(Stdlib.GetLastError())));
		}



		/// <summary>
		/// Writes the passed text using UTF-8 encoding w/o BOM.
		/// </summary>
		/// <param name="address">Address of a destination device</param>
		/// <param name="text"></param>
		public void WriteString(int address, string text)
		{
			WriteString (address, text, Encoding.UTF8);
		}


		/// <summary>
		/// Writes the passed text using the passed encoding.
		/// </summary>
		/// <param name="address">Address of a destination device</param>
		/// <param name="text"></param>
		/// <param name="encoding"></param>
		public void WriteString(int address, string text, Encoding encoding)
		{
			byte[] bytes = encoding.GetBytes(text);
			WriteBytes (address, bytes);
		}
	}
}