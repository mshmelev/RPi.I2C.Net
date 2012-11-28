using System.Text;

namespace RPi.I2C.Net
{
	public interface II2CBus
	{
		/// <summary>
		/// Writes single byte.
		/// </summary>
		/// <param name="address">Address of a destination device</param>
		/// <param name="b"></param>
		void WriteByte(int address, byte b);

		/// <summary>
		/// Writes array of bytes.
		/// </summary>
		/// <remarks>Do not write more than 3 bytes at once, RPi drivers don't support this currently.</remarks>
		/// <param name="address">Address of a destination device</param>
		/// <param name="bytes"></param>
		void WriteBytes(int address, byte[] bytes);


		/// <summary>
		/// Writes command with data.
		/// </summary>
		/// <param name="address"></param>
		/// <param name="command"></param>
		/// <param name="data"></param>
		void WriteCommand(int address, byte command, byte data);

		/// <summary>
		/// Writes command with data.
		/// </summary>
		/// <param name="address"></param>
		/// <param name="command"></param>
		/// <param name="data1"></param>
		/// <param name="data2"></param>
		void WriteCommand(int address, byte command, byte data1, byte data2);

		/// <summary>
		/// Writes command with data.
		/// </summary>
		/// <param name="address"></param>
		/// <param name="command"></param>
		/// <param name="data"></param>
		void WriteCommand(int address, byte command, ushort data);


		/// <summary>
		/// Reads bytes from device with passed address.
		/// </summary>
		/// <param name="address"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		byte[] ReadBytes(int address, int count);

	}
}