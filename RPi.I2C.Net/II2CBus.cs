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
		/// Writes the passed text using UTF-8 encoding w/o BOM.
		/// </summary>
		/// <param name="address">Address of a destination device</param>
		/// <param name="text"></param>
		void WriteString(int address, string text);


		/// <summary>
		/// Writes the passed text using the passed encoding.
		/// </summary>
		/// <param name="address">Address of a destination device</param>
		/// <param name="text"></param>
		/// <param name="encoding"></param>
		void WriteString(int address, string text, Encoding encoding);
	}
}