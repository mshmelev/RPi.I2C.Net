#include <stdio.h>
#include <linux/i2c.h>
#include <linux/i2c-dev.h>
#include <fcntl.h>
#include <string.h>
#include <sys/ioctl.h>
#include <unistd.h>
#include <errno.h>

#include "libNativeI2C.h"


int openBus (char* busFileName)
{
	return open (busFileName, O_RDWR);
}

int closeBus (int busHandle)
{
	return close (busHandle);
}

int writeBytes (int busHandle, int addr, byte* buf, int len)
{
	if (ioctl (busHandle, I2C_SLAVE, addr) < 0)
		return -1;

	if (write (busHandle, buf, len) != len)
		return -2;

	return len;
}

int readBytes (int busHandle, int addr, byte* buf, int len)
{
	if (ioctl (busHandle, I2C_SLAVE, addr) < 0)
		return -1;

	int n= read (busHandle, buf, len);

	return n;
}


int readRegister(int busHandle, int address, unsigned char reg, unsigned char *data) 
{
    unsigned char input_buffer, output_buffer;
    struct i2c_rdwr_ioctl_data packets;
    struct i2c_msg messages[2];

    output_buffer = reg;
    messages[0].addr  = address;
    messages[0].flags = 0;
    messages[0].len   = sizeof(output_buffer);
    messages[0].buf   = &output_buffer;

    messages[1].addr  = address;
    messages[1].flags = I2C_M_RD;
    messages[1].len   = sizeof(input_buffer);
    messages[1].buf   = &input_buffer;

    packets.msgs      = messages;
    packets.nmsgs     = 2;

    if(ioctl(busHandle, I2C_RDWR, &packets) < 0) {
        perror("Error sending data");
        return 1;
    }
    *data = input_buffer;

    return 0;
}

