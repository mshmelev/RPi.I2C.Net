#ifndef _rpi_i2c_c
#define _rpi_i2c_c

#define byte unsigned char

#ifdef __cplusplus
extern "C" {
#endif

extern int openBus (char*);
extern int closeBus (int);
extern int writeBytes (int, int, byte*, int);
extern int readBytes (int, int, byte*, int);


#ifdef __cplusplus
}
#endif

#endif
