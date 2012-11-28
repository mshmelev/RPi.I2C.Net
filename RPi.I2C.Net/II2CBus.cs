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

	}
}